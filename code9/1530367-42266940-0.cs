    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using System.Collections;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var @s = 
    @"<VariableCollection>
        <Variable Name='Level1'>
             <Variable Name='Level2'>
                   <Variable Name='Level3'>
                       <Variable Name='Level4'/>
                       <Variable Name='Level41'/>
                   </Variable>
             </Variable>
        </Variable>
        <Variable Name='Level11'>
             <Variable Name='Level21'>
                   <Variable Name='Level31'>
                       <Variable Name='Level41'/>
                       <Variable Name='Level42'/>
                       <Variable Name='Level43'/>
                   </Variable>
             </Variable>
        </Variable>
        <Variable Name='Level1'>
              <Variable Name='Level2'>
                   <Variable Name='Level3'/>
              </Variable>
        </Variable>
        <Variable Name='Level11'>
              <Variable Name='Level21'>
                   <Variable Name='Level31'/>
              </Variable>
        </Variable>
        <Variable Name='Level1'>
              <Variable Name='Level2'/>
        </Variable>
        <Variable Name='Level11'>
              <Variable Name='Level21'/>
        </Variable>
    </VariableCollection>";
