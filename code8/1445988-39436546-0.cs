    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;
    
    //using ConsoleApplication1;
    
    namespace TCPclient
    {
        [TestFixture]
     
        public class Program
        {
            [Test]
            public void Main1()
            {
    
                string response = GetCoctailString();
                try
                {
                    dynamic jsonData = JsonConvert.DeserializeObject(response);
                    List<Drink> drankjes = new List<Drink>();
    
                    for (int i = 0; i < jsonData.drinks.Count; i++)
                    {
    
                        try
                        {
                            string id = jsonData.drinks[i].idDrink;
                            string drink = jsonData.drinks[i].strDrink;
                            string category = jsonData.drinks[i].strCategory;
                            string instructions = jsonData.drinks[i].strInstructions;
                            string glass = jsonData.drinks[i].strGlass;
                            Console.WriteLine(glass);
                            var d = new Drink(id, drink, category, instructions);
    
                            drankjes.Add(d);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("error");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.ReadKey();
            }
            private static string GetCoctailString()
            {
                return "{ 'drinks':[{'idDrink':'15679','strDrink':'Midori Margarita','strCategory':'Ordinary Drink','strAlcoholic':'Alcoholic','strGlass':'Cocktail glass','strInstructions':'Moisten rim of cocktail glass with lime juice and dip in salt. Shake ingredients together, and pour into glass filled with crushed ice. Option: Mix above ingredients with one cup of ice in blender for a smooth, \"granita\" type drink.','strDrinkThumb':null,'strIngredient1':'Tequila','strIngredient2':'Triple sec','strIngredient3':'Lime juice','strIngredient4':'Midori melon liqueur','strIngredient5':'Salt','strIngredient6':'','strIngredient7':'','strIngredient8':'','strIngredient9':'','strIngredient10':'','strIngredient11':'','strIngredient12':'','strIngredient13':'','strIngredient14':'','strIngredient15':'','strMeasure1':'1 1/2 oz ','strMeasure2':'1/2 oz ','strMeasure3':'1 oz fresh ','strMeasure4':'1/2 oz ','strMeasure5':'\n','strMeasure6':'\n','strMeasure7':'\n','strMeasure8':'\n','strMeasure9':'\n','strMeasure10':'\n','strMeasure11':'','strMeasure12':'','strMeasure13':'','strMeasure14':'','strMeasure15':'','dateModified':null}]}";
            }
        }
        internal class Drink
        {
            public Drink(string idDrink, string strDrink, string strCategory, string strInstructions){}
            public string idDrink { get; set; }
            public string strDrink { get; set; }
            public string strCategory { get; set; }
            public string empty { get; set; }
            public string strInstructions { get; set; }
        }
    }
