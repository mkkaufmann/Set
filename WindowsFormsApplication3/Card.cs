using System;

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
        solid,
        striped,
        empty
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
    public Card(colors color, int num, patterns pattern, shapes shape)
    {
        cardColor = color;
        cardNum = num;
        cardPattern = pattern;
        cardShape = shape;
    }
}
