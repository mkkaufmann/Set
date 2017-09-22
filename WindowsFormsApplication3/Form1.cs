using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<PictureBox> boxes = new List<PictureBox>();
            boxes.AddRange(new PictureBox[]{ pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12});
            List<Image> images = new List<Image>();
            string fileName = "";
            string color = "";
            string pattern ="";
            string shape="";
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        color = "r";
                        break;
                    case 1:
                        color = "g";
                        break;
                    case 2:
                        color = "b";
                        break;
                }
                for (int j = 0; j < 3; j++)
                {
                    switch (j)
                    {
                        case 0:
                            pattern = "empty";
                            break;
                        case 1:
                            pattern = "solid";
                            break;
                        case 2:
                            pattern = "striped";
                            break;
                    }
                    for (int k = 0; k < 3; k++)
                    {
                        switch (k)
                        {
                            case 0:
                                shape = "circle";
                                break;
                            case 1:
                                shape = "square";
                                break;
                            case 2:
                                shape = "star";
                                break;
                        }
                        for (int l = 1; l < 4; l++)
                        {
                            fileName = color + pattern + shape + l.ToString();
                            images.Add(Image.FromFile(fileName));
                        }
                    }
                }
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
