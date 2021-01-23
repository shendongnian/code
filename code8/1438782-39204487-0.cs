    using System;
    namespace listSerial
    {
    class Program
    {
    public static void Main(string[] args)
    {
    string[] names = null;
    try{
    names = System.IO.Ports.SerialPort.GetPortNames();
    }catch(Exception ex){
    Console.WriteLine(ex.Message);
    }
    if(names!=null){
    int portnum = names.Length;
    if (portnum != 0){
    for (int i = 0; i < names.Length; i++)
    Console.WriteLine(names[i]);}
    else{
    Console.WriteLine("NO_COM");}
    }}}}
