using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        public List<Card> selectedCards = new List<Card>();
        public List<PictureBox> selectedBoxes = new List<PictureBox>();
        public int totalSets = 0;

        public Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            
            boxes.AddRange(new PictureBox[]{ pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12});
            allCards = GenerateDeck(loadImages());
            cardsInDeck = allCards;
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
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    for (int l = 0; l < 3; l++)
                    {
                        for (int j = 1; j < 4; j++)
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
                            fileName = "../Images/" + color + pattern + shape + l.ToString() + ".png";
                            images.Add(Image.FromFile(fileName));
                        }
                    }
                }
            }
            return images;
        }
        public bool verifySet(List<Card> cards)
        {
            List<Card.colors> colors = new List<Card.colors>();
            List<Card.patterns> patterns = new List<Card.patterns>();
            List<Card.shapes> shapes = new List<Card.shapes>();
            List<int> nums = new List<int>();
            foreach(Card card in cards)
            {
                colors.Add(card.cardColor);
                patterns.Add(card.cardPattern);
                shapes.Add(card.cardShape);
                nums.Add(card.cardNum);
            }
            /*if (!(colors.Any(o => o != colors[0]) || colors.Distinct().Count() == colors.Count()))
            {
                colorLabel.Text = "Color: False";
            }
            else
            {
                colorLabel.Text = "Color: True";
            }
            if (!(shapes.Any(o => o != shapes[0]) || shapes.Distinct().Count() == shapes.Count()))
            {
                shapeLabel.Text = "Shape: False";
            }
            else
            {
                shapeLabel.Text = "Shape: True";
            }
            if (!(patterns.Any(o => o != patterns[0]) || patterns.Distinct().Count() == patterns.Count()))
            {
                patternLabel.Text = "Pattern: False";
            }
            else
            {
                patternLabel.Text = "Pattern: True";
            }
            if (!(nums.Any(o => o != nums[0]) || nums.Distinct().Count() == nums.Count()))
            {
                numLabel.Text = "Number: False";
            }
            else
            {
                numLabel.Text = "Number: True";
            }*/
            if (!(colors.All(o => o == colors[0]) || colors.Distinct().Count() == colors.Count()))
            {
                return false;
            }
            if (!(shapes.All(o => o == shapes[0]) || shapes.Distinct().Count() == shapes.Count()))
            {
                return false;
            }
            if (!(patterns.All(o => o == patterns[0]) || patterns.Distinct().Count() == patterns.Count()))
            {
                return false;
            }
            if (!(nums.All(o => o == nums[0]) || nums.Distinct().Count() == nums.Count()))
            {
                return false;
            }
            //TODO
            return true;
        }
        private void pictureBox_Click(object sender, EventArgs e)//Handles all pictureBox clicks
        {
            PictureBox box = (PictureBox)sender;
            Image image = box.Image;
            Card clickedCard = null;
            if (selectedBoxes.Contains(box))
            {
                selectedBoxes.Remove(box);
                box.BorderStyle = BorderStyle.None;
                Card cardToRemove = null;
                foreach(Card card in selectedCards)
                {
                    if (image == card.cardImage)
                    {
                        cardToRemove = card;
                    }
                }
                selectedCards.Remove(cardToRemove);
                return;
            }
            box.BorderStyle = BorderStyle.FixedSingle;
            foreach (Card card in cardsInPlay)
            {
                if (card.cardImage == image)
                {
                    clickedCard = card;
                    selectedCards.Add(clickedCard);
                    selectedBoxes.Add(box);
                    if(selectedCards.Count() >= 3)
                    {
                        bool isSet = verifySet(selectedCards);
                        if (isSet)
                        {
                            totalSets++;
                            SetsLabel.Text = "Total # of Sets: " + totalSets.ToString();
                            foreach(PictureBox selectedBox in selectedBoxes)
                            {
                                Card pickedCard = cardsInDeck[random.Next(cardsInDeck.Count())];
                                selectedBox.Image = pickedCard.cardImage;
                                cardsInDeck.Remove(pickedCard);
                                cardsInPlay.Add(pickedCard);
                            }
                            foreach (Card selectedCard in selectedCards)
                            {
                                cardsInDeck.Add(selectedCard);
                            }
                        }
                        foreach(PictureBox selectedBox in selectedBoxes)
                        {
                            selectedBox.BorderStyle = BorderStyle.None;
                        }
                        
                        selectedCards.Clear();
                        selectedBoxes.Clear();
                    }

                    break;
                }
            }
            

        }
        
    }
}
