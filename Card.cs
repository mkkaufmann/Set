using System;
using System.Windows.Forms;
using System.Drawing;

public class Card
{
    public enum colors
    {
        red,
        green,
        blue
    };
    public enum patterns
    {
        empty,
        solid,
        striped
    };
    public enum shapes
    {
        circle,
        square,
        star
    }

    public colors cardColor;
    public int cardNum;
    public patterns cardPattern;
    public shapes cardShape;
    public PictureBox cardBox;
    public Image cardImage;
    public Card(colors color, int num, patterns pattern, shapes shape, Image image)
    {
        cardColor = color;
        cardNum = num;
        cardPattern = pattern;
        cardShape = shape;
        cardImage = image;
    }
}
