using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using DrOpen.DrData.DrDataObject;
using DrOpen.DrData.DrDataSx;


namespace DrDataSample
{
    class Program
    {

        static void Serialize2File()
        {
            var n = new DDNode("nodeName", "nodeType");
            n.Attributes.Add("valueInt", -1);

            using (var sw = new StreamWriter("file.xml"))
                n.Serialize(sw);

            DDNode k; //= new DDNode();

            using (var st = new StreamReader("file.xml"))
                k = DDNodeSxe.Deserialize(st);

            var ch1 = k.Add("1");
            var ch2 = k.Add("2");
            ch1.Rename("1");
            ch1.Rename("2");




        }


        static void Main(string[] args)
        {
            Serialize2File();
            try
            {
                var s = new string[] {"a\0bc", "def"};

                var b2 = Encoding.UTF8.GetBytes(s[0] + "\0\0" + s[1]);

                var attr = new DDValue();
                attr.SetValue("ddddd+ыыыы");


            }
            catch (Exception)
            {
                
                
            }



            var a = new DDNode("A");

            var b = a.Add("B");
            var c = b.Add("C");
            var z = b.Add(@".\.");
            c.Add();
            c.Add();
            c.Add();
            c.Add();
            c.Add();
            c.Add();

            c.Attributes.Add(new DDValue("value"));
            c.Attributes.Add(new DDValue("value"));
            c.Attributes.Add(new DDValue("value"));

            foreach (var node in c)
            {
                Debug.Print(node.Value.Name);
            }

            var d = a.Clone(true);
            //var ff = d.Attributes["fff"];
            // c.Add(b);
           
            d.Attributes.Add("ff", 123);
            
            var f = d.Attributes["ff"];
            var  t = d.Attributes.GetValue("ff", 56);
            var  r = d.Attributes.GetValue("fff", 56);
            d.Attributes.Add("Value");


            var ddNode = new DDNode("test");
            var ddNodeVars = ddNode.Add("Vars");
            var ddNodeActions = ddNode.Add("Actions");
            ddNodeVars.Attributes.Add("LogonName", "UserName");
            ddNodeVars.Attributes.Add("ExpectedResult", "false");
            ddNodeVars.Attributes.Add("ExpectedResult", "true", ResolveConflict.OVERWRITE);
            ddNodeVars.Attributes.GetValue("ExpectedResult", false).GetValueAsBool();
            ddNode.GetNode("/Vars").Attributes.GetValue("ExpectedResult", true).GetValueAsBool();

        }
    }
}
