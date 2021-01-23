    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                var strSource = "INFORMATION FOR THE PATIENT 10 mL Vial (1000 Units per vial) WARNINGS THIS LILLY HUMAN INSULIN PRODUCT DIFFERS FROM ANIMAL–SOURCE INSULINS BECAUSE IT IS STRUCTURALLY IDENTICAL TO THE INSULIN PRODUCED BY YOUR BODY’S PANCREAS AND BECAUSE OF ITS UNIQUE MANUFACTURING PROCESS. ANY CHANGE OF INSULIN SHOULD BE MADE CAUTIOUSLY AND ONLY UNDER MEDICAL SUPERVISION. CHANGES IN STRENGTH, MANUFACTURER, TYPE (E.G., REGULAR, NPH, ANALOG), SPECIES, OR METHOD OF MANUFACTURE MAY RESULT IN THE NEED FOR A CHANGE IN DOSAGE. SOME PATIENTS TAKING HUMULIN® (HUMAN INSULIN, rDNA ORIGIN) MAY REQUIRE A CHANGE IN DOSAGE FROM THAT USED WITH OTHER INSULINS. IF AN ADJUSTMENT IS NEEDED, IT MAY OCCUR WITH THE FIRST DOSE OR DURING THE FIRST SEVERAL WEEKS OR MONTHS. DIABETES Insulin is a hormone produced by the pancreas, a large gland that lies near the stomach. This hormone is necessary for the body’s correct use of food, especially sugar. Diabetes occurs when the pancreas does not make enough insulin to meet your body’s needs. To control your diabetes, your doctor has prescribed injections of insulin products to keep your blood glucose at a near–normal level. You have been instructed to test your blood and/or your urine regularly for glucose. Studies have shown that some chronic complications of diabetes such as eye disease, kidney disease, and nerve disease can be significantly reduced if the blood sugar is maintained as close to normal as possible. The American Diabetes Association recommends that if your pre–meal glucose levels are consistently above 130 mg/dL or your hemoglobin A1c (HbA1c) is more than 7%, you should talk to your doctor. A change in your diabetes therapy may be needed. If your blood tests consistently show below–normal glucose levels, you should also let your doctor know. Proper control of your diabetes requires close and constant cooperation with your doctor. Despite diabetes, you can lead an active and healthy life if you eat a balanced diet, exercise regularly, and take your insulin injections as prescribed by your doctor. Always keep an extra supply of insulin as well as a spare syringe and needle on hand. Always wear diabetic identification so that appropriate treatment can be given if complications occur away from home.";
                string[] strEnd = { ". ","? ","! " };
                var sentences = strSource.Split(strEnd,StringSplitOptions.None);
                foreach (var sentence in sentences)
                {
                    if (sentence.ToLower().Contains("blood"))
                    {
                        Console.WriteLine(sentence);
                    }
                }
                Console.ReadLine();
            }
        }
    }
