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
        public List<PictureBox> boxes = new List<PictureBox>();
        public List<Card> allCards;

        public List<Card> cardsInDeck;
        public List<Card> cardsInPlay = new List<Card>();
        public Form1()
        {
            InitializeComponent();
            
            boxes.AddRange(new PictureBox[]{ pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12});
            allCards = GenerateDeck(loadImages());
            cardsInDeck = allCards;
            Random random = new Random();
            foreach (PictureBox box in boxes)
            {
                Card selectedCard = cardsInDeck[random.Next(cardsInDeck.Count())];
                cardsInDeck.Remove(selectedCard);
                cardsInPlay.Add(selectedCard);
                box.Image = selectedCard.cardImage;

            }
        }
        public List<Card> GenerateDeck(List<Image> images)
        {
            List<Card> cards = new List<Card>();
            int imageIndex = 0;
            for (int i = 0; i < 3; i++) {
                for (int j = 1; j <= 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        for (int l = 0; l < 3; l++)
                        {
                            cards.Add(new Card((Card.colors)i, j, (Card.patterns)k, (Card.shapes)l, images[imageIndex]));
                            imageIndex++;
                        }
                    }
                }
            }
            return cards;
        }
        public List<Image> loadImages()
        {
            List<Image> images = new List<Image>();
            string fileName = "";
            string color = "";
            string pattern = "";
            string shape = "";
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
                            fileName = "../../" + color + pattern + shape + l.ToString() + ".png";
                            images.Add(Image.FromFile(fileName));
                        }
                    }
                }
            }
            return images;
        }
        private void pictureBox_Click(object sender, EventArgs e)//Handles all pictureBox clicks
        {

        }
    }
}
