using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Schema;

namespace serializacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();

            if (openfiledialog.ShowDialog() == DialogResult.OK)
            {
                var path = openfiledialog.FileName;


                XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));

                StreamReader reader = new StreamReader(path);

                var input = serializer.Deserialize(reader);
                reader.Close();
                dataGridView1.DataSource = input;

              
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog filedialog = new SaveFileDialog();
            if (filedialog.ShowDialog() == DialogResult.OK)
            {
                var path = filedialog.FileName;
                XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
                StreamWriter writer = new StreamWriter(path);

                serializer.Serialize(writer, dataGridView1.DataSource);
                writer.Close();
            }
        }

    }
}
