using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work1_lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape r1 = new Rectangle(-1, 21);
            Shape s1 = new Square(33);
            Shape t1 = new Triangle(13, 22, 33);
            ShapeFactory shapeFactory = new ShapeFactory();
            Shape s = shapeFactory.CreatShape("Rectangle", 1, 21, 1);
            Console.WriteLine("面积分别为{0},{1},{2},{3}", r1.CalculateArea(), s1.CalculateArea(), t1.CalculateArea(),s.CalculateArea());
            int sum = 0;
            Shape[] shape = new Shape[10];
            Random random = new Random();
            for (int i=0;i<10;i++)
            {
                int r=random.Next(1, 4);
                switch(r)
                {
                    case 1:
                        shape[i] = shapeFactory.CreatShape("Rectangle", random.Next()+1, random.Next()+1, random.Next()+1);
                        break;
                    case 2:
                        shape[i] = shapeFactory.CreatShape("Rectangle", random.Next() + 1, random.Next() + 1, random.Next() + 1);
                        break;
                    case 3:
                        shape[i] = shapeFactory.CreatShape("Rectangle", random.Next() + 1, random.Next() + 1, random.Next() + 1);
                        break;
                }
            }

            Console.ReadKey();
        }
    }

    public interface Shape
    {
        double CalculateArea();
        bool Legalize();
    }

    public class Rectangle:Shape
    {
        int length;
        int width;

        public Rectangle(int length,int width)
        {
            this.length = length;
            this.width = width;
            if (!this.Legalize())
                Console.WriteLine(this.GetType()+"创建非法！");
        }
        public double CalculateArea()
        {
            return (length * width);
        }
        public bool Legalize()
        {
            return ((length > 0 && width > 0) ? true : false);
        }
    }

    public class Square:Shape
    {
        int length;

        public Square(int length)
        {
            this.length = length;
            if (!this.Legalize())
                Console.WriteLine(this.GetType() + "创建非法！");
        }

       public double CalculateArea()
        {
            return length * length;
        }

       public bool Legalize()
        {
            return (length > 0 ? true : false);
        }
    }

    public class Triangle:Shape
    {
        int length1, length2, length3;

        public Triangle(int length1,int length2,int length3)
        {
            this.length1 = length1;
            this.length2 = length2;
            this.length3 = length3;
            if (!this.Legalize())
                Console.WriteLine(this.GetType() + "创建非法！");
        }

        public double CalculateArea()
        {
            double p = (length3 + length2 + length1) / 2;
            double S = Math.Sqrt(p*(p - length1)*(p - length2)*(p - length3));
            return S;
        }

        public bool Legalize()
        {
            if(length1>0&&length2>0&&length3>0)
            {
                if (length3 + length2 > length1 || length1 + length2 > length3 || length1 + length3 > length2)
                    return true;
                return false;
            }
            return false;
        }
    }

    public class ShapeFactory
    {
        public Shape CreatShape(String Type, int length1, int length2, int length3)
        {
            switch (Type)
            {
                case "Rectangle":
                    return new Rectangle(length1, length2);
                case "Square":
                    return new Square(length1);
                case "Triangle":
                    return new Triangle(length1, length2, length3);
                default:
                    return null;
            }
        }
    }
}
