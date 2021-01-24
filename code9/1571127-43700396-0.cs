    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using System.IO;
    namespace ConsoleApplication3
    {
        class Program
        {
            static void createAcc()
            {
                string[] a = new string[2];
                Console.Write("Digite uma nova senha(password): ");
                a[0] = Console.ReadLine();
                Console.Write("Entre com o caminho escondido(folder path): ");
                string s = Console.ReadLine();
                a[1] = encryptsOrDecrypts(s,'e');
                File.WriteAllLines("MyFile.txt", a);
                Console.Write("Conta criada com sucesso. Feche e abra novamente e insira sua senha.");
                Console.ReadKey();
            }
    
            static string encryptsOrDecrypts(string a, char mode)
            {
                if (mode == 'e')
                {
                    string encrypted = "";
                    foreach (char s in a)
                    {
                        encrypted += (Convert.ToInt32(s) + 1) + ",";
    
                    }
                    encrypted = encrypted.Remove(encrypted.Length - 1);
                    return encrypted;
                }else{
    
                    string decrypted = "";
                    string[] str = a.Split(',');
                    for(int i = 0; i < str.Length; i++)
                    {
                        decrypted += (char)(Convert.ToInt32(str[i]) - 1);
    
                    }
                    return decrypted;
                }
    
            }
            static bool checkPassword(string input)
            {
                try
                {
                    string[] linesI = File.ReadAllLines("MyFile.txt");
                    if (linesI[0] == input)
                    {
                        return true;
                    }
                    else
                    {
                        Console.Write("Senha errada(Wrong password)");
                        Console.ReadKey();
                        return false;
                    }
                }
                catch (FileNotFoundException e)
                {
                    Console.Write("Arquivo 'MyFiles.txt' não existe ou conta não criada. Fecha e abra novamente.");
                    Console.ReadKey();
                    return false;
                }
            }
            static void Main(string[] args)
            {
                string a;
                Console.WriteLine("Senha(digite new para criar uma nova conta(new to a new account)):");
                a = Console.ReadLine();
                if (a == "new")
                {
                    createAcc();
                }
                else
                if (checkPassword(a))
                {
                    
                    //File.WriteAllLines("MyFile.txt", linesI);
                    string[] linesO = File.ReadAllLines("MyFile.txt");
                    string output = encryptsOrDecrypts(linesO[1], 'd'); 
                    Console.ReadKey();
                    Process.Start("explorer.exe", output);
                }
            }
        }
    }
