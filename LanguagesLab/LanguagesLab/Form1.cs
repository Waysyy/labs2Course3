using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LanguagesLab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e){}
        public List<ProgrammingLanguage> listLang2 = new List<ProgrammingLanguage>();
        public static class Transformation
        {
            public class Languages : Elements
            {
                public List<ProgrammingLanguage> listLang = new List<ProgrammingLanguage>();
                public override List<ProgrammingLanguage> RetList()
                {                                 
                    var xDoc = XDocument.Load(Environment.CurrentDirectory + "\\lang.xml");
                    foreach (var data in xDoc.Element("languages").Elements("lang"))
                    {
                        listLang.Add(new ProgrammingLanguage { Name = data.Attribute("name").Value, Appeared = Convert.ToInt32(data.Element("appeared").Value), Creator = data.Element("creator").Value });                       
                    }
                    return listLang;
                }          
            }
        }
        public class ProgrammingLanguage
        {
            public string Name { get; set; }
            public int Appeared { get; set; }
            public string Creator { get; set; }            
        }
        public abstract class Elements
        {
            public abstract List<ProgrammingLanguage> RetList();               
        }
        public void SetDataGrid()
        {
            Transformation.Languages dt = new Transformation.Languages();

            dataGridView1.Columns.Add("Column1", "Name");
            dataGridView1.Columns.Add("Column2", "Appeared");
            dataGridView1.Columns.Add("Column3", "Creator");
                        
            listLang2 = (dt.RetList());
            foreach (var i in listLang2)
            {
                dataGridView1.Rows.Add(i.Name, i.Appeared, i.Creator);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {            
            SetDataGrid();
        }
    }
}