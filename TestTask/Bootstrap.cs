namespace TestTask
{
    internal class Bootstrap
    {
        public Bootstrap()
        {
            var logic = new Logic();
            logic.CreateSecondaryRectangle(Color.Pink, new Point(1, 1), new Point(5, 5));
            logic.CreateSecondaryRectangle(Color.Green, new Point(1, 6), new Point(8, 9));
            logic.CreateSecondaryRectangle(Color.Green, new Point(7, 3), new Point(11, 7));


            logic.CreateMainRectangle(new Rectangle(new Point(0, 0), new Point(9, 8)), false);
            //небольшое пояснение: ignoreOutDots это параметр отвечающий за то, необходимо ли включать точки которые не попали в основной прямоугольник
            //false - первое задание
            //true - второе


            // logic.CreateMainRectangle(new Rectangle(Color.Green, new Point(0, 0), new Point(9, 8)), false, Color.Green);
            //logic.CreateMainRectangle(new Rectangle(Color.Green, new Point(0, 0), new Point(9, 8)), true, Color.Green, Color.Pink);
            //logic.CreateMainRectangle(new Rectangle(Color.Green, new Point(0, 0), new Point(9, 8)), true, Color.Green, Color.Purple);
        }
    }
}