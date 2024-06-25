namespace TestTask
{
    public class Rectangle 
    {
        public readonly Color Color;
        public readonly Point BotLeft;
        public readonly Point TopRight; //в тз ошибка/опечатка, у вас дано BotLeft и TopLeft (а они находятся на одной пряммой, левой стороне)
        
        public Rectangle(Color color, Point botLeft, Point topRight)
        {
            this.Color = color;
            BotLeft = botLeft;
            TopRight = topRight;
        }

        public Rectangle(Point botLeft, Point topRight)
        {
            BotLeft = botLeft;
            TopRight = topRight;
        }
        
        public bool Contains(Point p)
        {
            return p.X >= BotLeft.X && p.X <= TopRight.X && p.Y >= BotLeft.Y && p.Y <= TopRight.Y;
        }
    }
}