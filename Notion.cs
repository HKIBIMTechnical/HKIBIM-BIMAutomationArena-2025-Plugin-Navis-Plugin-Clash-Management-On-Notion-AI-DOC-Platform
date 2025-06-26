using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;
using Autodesk.Navisworks.Api.DocumentParts;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using Autodesk.Navisworks.Api.Clash;
namespace Notion
{ 

    [PluginAttribute("Notion", "andy", ToolTip = "this is a test", DisplayName = "Notion")]

    [AddInPluginAttribute(AddInLocation.None)]

    public class Notion : AddInPlugin
    { 
        public static Notion_Form form;
         
        public override int Execute(params string[] parameters)
        {

            form = new Notion_Form();
            form.Show();

            return 0;
        }
    }
}
