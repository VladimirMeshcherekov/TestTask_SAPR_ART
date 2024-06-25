using System;
using System.Collections.Generic;
using System.Linq;

namespace TestTask
{
    public class Logic
    {
        public List<Rectangle> SecondaryRectangles { get; private set; }

        public Logic()
        {
            SecondaryRectangles = new List<Rectangle>();
        }
        
        public void CreateSecondaryRectangle(Color color, Point botLeft, Point topRight)
        {
            SecondaryRectangles.Add(new Rectangle(color, botLeft, topRight));
            Console.WriteLine(
                $"Added new Secondary Rectangle with: Color: {color}, Bottom: ({botLeft.X}; {botLeft.Y}), UP: ({topRight.X}, {topRight.Y})");
        }
        
        public Rectangle CreateMainRectangle(Rectangle mainRectangle, bool ignoreOutDots)
        {
         return CreateRectangleByPoints(FindPoints(mainRectangle, SecondaryRectangles, ignoreOutDots));
        }

        public Rectangle CreateMainRectangle(Rectangle mainRectangle, bool ignoreOutDots, params Color[] filteredColors)
        {
            var filteredRectangles = SecondaryRectangles.Where(r => filteredColors.Contains(r.Color)).ToList();
            return CreateRectangleByPoints(FindPoints(mainRectangle, filteredRectangles, ignoreOutDots));
        }

        private List<Point> FindPoints(Rectangle mainRectangle, List<Rectangle> filteredRectangles, bool ignoreOutDots)
        {
            var points = new List<Point>();

            if (ignoreOutDots)
                foreach (var rec in filteredRectangles)
                {
                    if (mainRectangle.Contains(rec.BotLeft)) points.Add(rec.BotLeft);
                    if (mainRectangle.Contains(rec.TopRight)) points.Add(rec.TopRight);

                    var upLeft = new Point(rec.BotLeft.X, rec.TopRight.Y);
                    if (mainRectangle.Contains(upLeft)) points.Add(upLeft);

                    var botRight = new Point(rec.TopRight.X, rec.BotLeft.Y);
                    if (mainRectangle.Contains(botRight)) points.Add(botRight);
                }

            else
                foreach (var rectangle in filteredRectangles)
                {
                    points.Add(rectangle.BotLeft);
                    points.Add(rectangle.TopRight);
                }

            return points;
        }
        private Rectangle CreateRectangleByPoints(List<Point> points)
        {
            var minX = points.Min(p => p.X);
            var minY = points.Min(p => p.Y);
            var maxX = points.Max(p => p.X);
            var maxY = points.Max(p => p.Y);
            
            Console.WriteLine(
                $"Created new main rectangle with: Bottom: ({minX}; {minY}), UP: ({maxX}, {maxY})");
            return new Rectangle(Color.Green, new Point(minX, minY), new Point(maxX, maxY));
        }
    }
}
