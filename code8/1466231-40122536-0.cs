    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using System;
    
    public class QuadTree
    {
    
        public QuadTree parent = null;
        public QuadTree[] childern = null;
        public List<PPObject> objectList = null;
        public BBox bbox = null;
    
        public bool leaf = true;
        public float minSize = 1.0f;
        public float maxObjs = 4;
    
        public float width;
        public float height;
        public Vector3 position;
        public int level;
    
        public QuadTree(QuadTree parent, BBox bbox, List<PPObject> objectList, int level)
        {
            this.parent = parent;
            this.bbox = bbox;
            this.level = level;
            width = bbox.xmax - bbox.xmin;
            height = bbox.ymax - bbox.ymin;
            position = new Vector3(bbox.xmin + width * 0.5f, bbox.ymin + height * 0.5f, 0.0f);
    
            this.objectList = objectList;
            BuildTree();
        }
    
        public QuadTree(QuadTree parent, BBox bbox, int level)
        {
            this.parent = parent;
            this.bbox = bbox;
            this.level = level;
            width = bbox.xmax - bbox.xmin;
            height = bbox.ymax - bbox.ymin;
            position = new Vector3(bbox.xmin + width * 0.5f, bbox.ymin + height * 0.5f, 0.0f);
    
            objectList = new List<PPObject>();
        }
    
        public void Subdivide()
        {
            if (objectList.Count > maxObjs && childern == null && width > minSize && height > minSize)
            {
                float x1 = bbox.xmin;
                float x2 = bbox.xmin + 0.5f * width;
                float x3 = bbox.xmax;
                float y1 = bbox.ymin;
                float y2 = bbox.ymin + height * 0.5f;
                float y3 = bbox.ymax;
    
                childern = new QuadTree[4];
                BBox tlBBox = new BBox(x1, x2, y2, y3);
                BBox trBBox = new BBox(x2, x3, y2, y3);
                BBox brBBox = new BBox(x2, x3, y1, y2);
                BBox blBBox = new BBox(x1, x2, y1, y2);
    
                QuadTree tl = new QuadTree(this, tlBBox, level + 1);
                QuadTree tr = new QuadTree(this, trBBox, level + 1);
                QuadTree br = new QuadTree(this, brBBox, level + 1);
                QuadTree bl = new QuadTree(this, blBBox, level + 1);
    
                foreach (PPObject obj in objectList)
                {
                    tl.AddObject(obj);
                    tr.AddObject(obj);
                    br.AddObject(obj);
                    bl.AddObject(obj);
                }
    
                childern[0] = tl;
                childern[1] = tr;
                childern[2] = br;
                childern[3] = bl;
    
                objectList = new List<PPObject>();
    
                leaf = false;
    
            }
            else if (childern != null)
            {
                PushToChildern();
            }
        }
    
        public void PushToChildern()
        {
            foreach (QuadTree child in childern)
            {
                foreach (PPObject obj in objectList)
                {
                    child.AddObject(obj);
                }
            }
    
            objectList = null;
        }
    
        public bool CheckBounds(PPObject obj, BBox region)
        {
            float x1 = obj.position.x;
            float w1 = obj.bbox.xmax - obj.bbox.xmin;
    
            float y1 = obj.position.y;
            float h1 = obj.bbox.ymax - obj.bbox.ymin;
    
            float dx = Math.Abs(x1 - position.x);
    
            float dy = Math.Abs(y1 - position.y);
    
            if (dx < ((width + w1) * 0.5f) && dy < (height + h1) * 0.5f)
            {
                return true;
            }
            return false;
        }
    
        /*
         * Make this faster by building the list to push here
         */
        public void AddObject(PPObject obj)
        {
            if (obj != null)
            {
                if (CheckBounds(obj, bbox))
                {
                    objectList.Add(obj);
                }
            }
        }
    
        public void BuildTree()
        {
            Subdivide();
            if (childern != null)
            {
                foreach(QuadTree child in childern)
                {
                    child.BuildTree();
                }
            }
        }
    }
