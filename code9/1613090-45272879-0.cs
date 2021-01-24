    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                User user = new User();
                var characterList = (from characters in ContextFactory.Instance.Characters
                where characters.UserId == user.Id
                join traits in ContextFactory.Instance.CharacterTraits
                on characters.Id equals traits.CharacterId
                join clothes in ContextFactory.Instance.CharacterClothes
                on characters.Id equals clothes.CharacterId
                select new { characters = characters, traits = traits, clothes = clothes })
                .GroupBy(x => x.characters.Id)
                .Select(x => new { 
                    id = x.FirstOrDefault().characters.Id, 
                    name = x.FirstOrDefault().characters.Name, 
                    gender = x.FirstOrDefault().characters.Gender, 
                    level = x.FirstOrDefault().characters.Level, 
                    money = x.FirstOrDefault().characters.Money, 
                    bank = x.FirstOrDefault().characters.Bank, 
                    lastLogin = x.FirstOrDefault().characters.LastLogin, 
                    playedTime = x.FirstOrDefault().characters.PlayedTime, 
                    traits = x.FirstOrDefault().traits, 
                    clothes = x.Select(y => y.clothes.clothes).ToArray()
                }).FirstOrDefault();
            }
        }
        public class ContextFactory
        {
            public static Instance Instance = null;
        }
        public class Instance
        {
            public List<Characters> Characters;
            public List<CharactersTraits> CharacterTraits;
            public List<CharactersClothes> CharacterClothes;
        }
        public class Characters
        {
            public int Id;
            public int UserId;
            public string Name;
            public string Gender;
            public string Level;
            public string Money;
            public string Bank;
            public string LastLogin;
            public string PlayedTime;
        }
        public class CharactersTraits
        {
            public int CharacterId;
        }
        public class CharactersClothes
        {
            public int CharacterId;
            public string clothes;
        }
        public class User
        {
            public int Id;
        }
    }
