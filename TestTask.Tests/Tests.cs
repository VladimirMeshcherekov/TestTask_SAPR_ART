using System;
using NUnit.Framework;
using TestTask;

namespace TestTask.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Logic logic = new Logic();
            logic.CreateSecondaryRectangle(Color.Pink, new Point(1, 1), new Point(5, 5));
            logic.CreateSecondaryRectangle(Color.Green, new Point(1, 6), new Point(8, 9));
            logic.CreateSecondaryRectangle(Color.Green, new Point(7, 3), new Point(11, 7));
            Rectangle rectangle = logic.CreateMainRectangle(new Rectangle(new Point(0, 0), new Point(9, 8)), false);

            if (rectangle.BotLeft.X == 1 && rectangle.BotLeft.Y ==1 && rectangle.TopRight.X == 11 && rectangle.TopRight.Y == 9)
            {
                 Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
           
        }
        
        
        [Test]
        public void Test2()
        {
            Logic logic = new Logic();
            logic.CreateSecondaryRectangle(Color.Pink, new Point(1, 1), new Point(5, 5));
            logic.CreateSecondaryRectangle(Color.Green, new Point(1, 6), new Point(8, 9));
            logic.CreateSecondaryRectangle(Color.Green, new Point(7, 3), new Point(11, 7));
            Rectangle rectangle = logic.CreateMainRectangle(new Rectangle(new Point(0, 0), new Point(9, 8)), true);

            if (rectangle.BotLeft.X == 1 && rectangle.BotLeft.Y ==1 && rectangle.TopRight.X == 8 && rectangle.TopRight.Y == 7)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
           
        } 
        
        
        [Test]
        public void Test3()
        {
            Logic logic = new Logic();
            logic.CreateSecondaryRectangle(Color.Pink, new Point(1, 1), new Point(5, 5));
            logic.CreateSecondaryRectangle(Color.Green, new Point(1, 6), new Point(8, 9));
            logic.CreateSecondaryRectangle(Color.Green, new Point(7, 3), new Point(11, 7));
            Rectangle rectangle = logic.CreateMainRectangle(new Rectangle(new Point(0, 0), new Point(9, 8)), true, Color.Green);

            if (rectangle.BotLeft.X == 1 && rectangle.BotLeft.Y ==3 && rectangle.TopRight.X == 8 && rectangle.TopRight.Y == 7)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
           
        }
        
        [Test]
        public void Test4()
        {
            Logic logic = new Logic();
            logic.CreateSecondaryRectangle(Color.Pink, new Point(1, 1), new Point(5, 5));
            logic.CreateSecondaryRectangle(Color.Green, new Point(1, 6), new Point(8, 9));
            logic.CreateSecondaryRectangle(Color.Green, new Point(7, 3), new Point(11, 7));
            Rectangle rectangle = logic.CreateMainRectangle(new Rectangle(new Point(0, 0), new Point(9, 8)), false, Color.Green);

            if (rectangle.BotLeft.X == 1 && rectangle.BotLeft.Y ==3 && rectangle.TopRight.X == 11 && rectangle.TopRight.Y == 9)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
           
        }
     
        
        [Test]
        public void Test5()
        {
            Logic logic = new Logic();
            logic.CreateSecondaryRectangle(Color.Green, new Point(1, 1), new Point(5, 5));
            logic.CreateSecondaryRectangle(Color.Green, new Point(1, 6), new Point(8, 9));
            logic.CreateSecondaryRectangle(Color.Green, new Point(7, 3), new Point(11, 7));
            Rectangle rectangle = logic.CreateMainRectangle(new Rectangle(new Point(0, 0), new Point(9, 8)), false, Color.Green);

            if (rectangle.BotLeft.X == 1 && rectangle.BotLeft.Y ==1 && rectangle.TopRight.X == 11 && rectangle.TopRight.Y == 9)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
           
        }
    }
}