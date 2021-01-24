            public IEnumerable<DiscussionDTO> GetAll()
        {
            var all = _ctx.Discussions.ToArray();
            var discussionDTO = Mapper.Map<IEnumerable<Discussion>, IEnumerable<DiscussionDTO>>(all);
            return discussionDTO;
        }
