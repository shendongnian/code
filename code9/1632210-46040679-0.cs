    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class Gallery : MonoBehaviour
    {
    
    public float timer;
    public Sprite[] gallerySprites;
    public Image currentImage;
    public int ImagesLoopIndex = 0;
    
    public int newRandomNummer;
    int lastRandomNumber;
    int min = 0;
    int max;
    
    public Gallery[] galleries;
    
    public List<int> val = new List<int>();
    
    // Use this for initialization
    void Start()
    {
        ShuffleImagesList();
        max = gallerySprites.Length;
        timer = MakeRandomNumber(8, 18);
    }
    
    private void ShuffleImagesList()
    {
        for (int i = 0; i < galleries.lenght -1; i++) 
        {
             Gallery[] temp = galleries[i];
             int randomIndex = Random.Range(i, galleries.lenght-1);
             galleries[i] = galleries[randomIndex];
             galleries[randomIndex] = temp;
         }
    
    }
    // Update is called once per frame
    void Update()
    {
    
        timer -= Time.deltaTime;
    
        if (timer <= 0)
        {
    
    
            StartCoroutine(fadeImages());
            timer = MakeRandomNumber(8, 18);
    
    
        }
    
    }
    
    IEnumerator fadeImages()
    {
        if (ImagesLoopIndex >= galleries.lenght)
        {
            ShuffleImagesList();
            ImagesLoopIndex = 0;
        }
        else
        {
            currentImage.CrossFadeAlpha(0, 1f, false);
            yield return new WaitForSeconds(1f);
            currentImage.CrossFadeAlpha(1, 1f, false);
            currentImage.sprite = gallerySprites[MakeRandomNumber(0, max)]; 
            ImagesLoopIndex = ImagesLoopIndex +1;
       }
    }
