using DocumentFormat.OpenXml.Spreadsheet;
using System.Drawing;


public class Leaf
{
    protected int MIN_LEAF_SIZE = 20;

    public int x, y, width, height;

    public Leaf leftChild, rightChild;

    public List<Point> roomStat = new List<Point>();

    public List<Point> halls;
    

    //public Point roomSize, roomPos;

    public Leaf(int x, int y, int width, int height)
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }

    public bool Split()
    {
        if (leftChild != null || rightChild != null)
        {
            return false;
        }

        Random random = new Random();
        bool splitH = random.NextDouble() > 0.5;

        if (width > height && Convert.ToDouble(width) / Convert.ToDouble(height) >= 1.25)
        {
            splitH = false;
        }
        else if (height > width && Convert.ToDouble(height) / Convert.ToDouble(width) >= 1.25)
        {
            splitH = true;
        }

        int max = (splitH ? height : width) - MIN_LEAF_SIZE;
        if (max <= MIN_LEAF_SIZE)
        {
            return false;
        }

        int split = random.Next(MIN_LEAF_SIZE, max);

        if (splitH)
        {
            leftChild = new Leaf(x, y, width, split);
            rightChild = new Leaf(x, y + split, width, height - split);
        }
        else
        {
            leftChild = new Leaf(x, y, split, height);
            rightChild = new Leaf(x + split, y, width - split, height);
        }

        return true;
    }

    public void CreateRooms()
    {
        if (leftChild != null || rightChild != null)
        {
            if (leftChild != null)
            {
                leftChild.CreateRooms();
            }

            if (rightChild != null)
            {
                rightChild.CreateRooms();
            }

            if (leftChild != null && rightChild != null)
            {
                CreateHall(leftChild.GetRoom(), rightChild.GetRoom());
            }
        }
        else
        {
            Point roomSize = new Point((new Random()).Next(15, width - 2), (new Random()).Next(5, height - 10));
            Point roomPos = new Point((new Random()).Next(1, width - roomSize.X - 1) + x, (new Random()).Next(1, height - roomSize.Y - 1) + y);
            roomStat.Add(roomPos);
            roomStat.Add(roomSize);
        }
    }

    public List<Point>? GetRoom()
    {
        if (roomStat.Count() > 0) return roomStat;
        else
        {
            List<Point> lRoom = new List<Point>(), rRoom = new List<Point>();

            if (leftChild != null) lRoom = leftChild.GetRoom();
            if (rightChild != null) rRoom = rightChild.GetRoom();

            if (lRoom.Count == 0 && rRoom.Count == 0) return null;
            else if (rRoom.Count == 0) return lRoom;
            else if (lRoom.Count == 0) return rRoom;
            else if (new Random().NextDouble() > 0.5) return lRoom;
            else return rRoom;
        }
    }

    public void CreateHall(List<Point> l, List<Point> r)
    {
        halls = new List<Point>();

        Point p1 = new Point(new Random().Next(l[0].X + 1, l[0].X + l[1].X - 2), new Random().Next(l[0].Y + 1, l[0].Y + l[1].Y - 2));
        Point p2 = new Point(new Random().Next(r[0].X + 1, r[0].X + r[1].X - 2), new Random().Next(r[0].Y + 1, r[0].Y + r[1].Y - 2));

        int w = p2.X - p1.X;
        int h = p2.Y - p1.Y;

        if (w < 0)
        {
            if (h < 0)
            {
                if (new Random().NextDouble() < 0.5)
                {
                    for (int i = p2.X; i <= p2.X + Math.Abs(w); i++)
                    {
                        halls.Add(new Point(i, p1.Y));
                    }
                    for (int i = p2.Y; i <= p2.Y + Math.Abs(h); i++)
                    {
                        halls.Add(new Point(p2.X, i));
                    }
                }
                else
                {
                    for (int i = p2.X; i <= p2.X + Math.Abs(w); i++)
                    {
                        halls.Add(new Point(i, p2.Y));
                    }
                    for (int i = p2.Y; i <= p2.Y + Math.Abs(h); i++)
                    {
                        halls.Add(new Point(p1.X, i));
                    }
                }
            }
            else if (h > 0)
            {
                if (new Random().NextDouble() < 0.5)
                {
                    for (int i = p2.X; i <= p2.X + Math.Abs(w); i++)
                    {
                        halls.Add(new Point(i, p1.Y));
                    }
                    for (int i = p1.Y; i <= p1.Y + Math.Abs(h); i++)
                    {
                        halls.Add(new Point(p2.X, i));
                    }
                }
                else
                {
                    for (int i = p2.X; i <= p2.X + Math.Abs(w); i++)
                    {
                        halls.Add(new Point(i, p2.Y));
                    }
                    for (int i = p1.Y; i <= p1.Y + Math.Abs(h); i++)
                    {
                        halls.Add(new Point(p1.X, i));
                    }
                }
            }
            else
            {
                for (int i = p2.X; i <= p2.X + Math.Abs(w); i++)
                {
                    halls.Add(new Point(i, p2.Y));
                }
            }
        }
        else if (w > 0)
        {
            if (h < 0)
            {
                if (new Random().NextDouble() < 0.5)
                {
                    for (int i = p1.X; i <= p1.X + Math.Abs(w); i++)
                    {
                        halls.Add(new Point(i, p2.Y));
                    }
                    for (int i = p2.Y; i <= p2.Y + Math.Abs(h); i++)
                    {
                        halls.Add(new Point(p1.X, i));
                    }
                }
                else
                {
                    for (int i = p1.X; i <= p1.X + Math.Abs(w); i++)
                    {
                        halls.Add(new Point(i, p1.Y));
                    }
                    for (int i = p2.Y; i <= p2.Y + Math.Abs(h); i++)
                    {
                        halls.Add(new Point(p2.X, i));
                    }
                }
            }
            else if (h > 0)
            {
                if (new Random().NextDouble() < 0.5)
                {
                    for (int i = p1.X; i <= p1.X + Math.Abs(w); i++)
                    {
                        halls.Add(new Point(i, p1.Y));
                    }
                    for (int i = p1.Y; i <= p1.Y + Math.Abs(h); i++)
                    {
                        halls.Add(new Point(p2.X, i));
                    }
                }
                else
                {
                    for (int i = p1.X; i <= p1.X + Math.Abs(w); i++)
                    {
                        halls.Add(new Point(i, p2.Y));
                    }
                    for (int i = p1.Y; i <= p1.Y + Math.Abs(h); i++)
                    {
                        halls.Add(new Point(p1.X, i));
                    }
                }
            }
            else
            {
                for (int i = p1.X; i <= p1.X + Math.Abs(w); i++)
                {
                    halls.Add(new Point(i, p1.Y));
                }
            }
        }
        else
        {
            if (h < 0)
            {
                for (int i = p2.Y; i <= p2.Y + Math.Abs(h); i++)
                {
                    halls.Add(new Point(p2.X, i));
                }
            }
            else if (h > 0)
            {
                for (int i = p1.Y; i <= p1.Y + Math.Abs(h); i++)
                {
                    halls.Add(new Point(p1.X, i));
                }
            }
        }
    }

}

public class Map
{

    public const int MAP_WIDTH = 150;
    public const int MAP_HEIGHT = 60;

    public char[,] map = new char[MAP_HEIGHT, MAP_WIDTH];
    public char[,] map2 = new char[MAP_HEIGHT, MAP_WIDTH];
    public void CreateMap()
    {
        int MAX_LEAF_SIZE = 50;

        List<Leaf> leafs = new List<Leaf>();

        Leaf root = new Leaf(0, 0, MAP_WIDTH, MAP_HEIGHT);

        leafs.Add(root);

        bool did_split = true;

        while (did_split)
        {
            did_split = false;

            for (int i = 0; i < leafs.Count; i++)
            {
                Leaf leaf = leafs[i];

                if (leaf.leftChild == null && leaf.rightChild == null)
                {
                    Random random = new Random();
                    if (leaf.width > MAX_LEAF_SIZE || leaf.height > MAX_LEAF_SIZE || random.NextDouble() > 0.25)
                    {
                        if (leaf.Split())
                        {
                            leafs.Add(leaf.leftChild);
                            leafs.Add(leaf.rightChild);
                            did_split = true;
                        }
                    }
                }
            }
        }

        root.CreateRooms();

        for (int i = 0; i < MAP_HEIGHT; i++)
        {
            for (int j = 0; j < MAP_WIDTH; j++)
            {
                map[i, j] = ' ';
                map2[i, j] = ' ';
            }
        }

        foreach (Leaf leaf in leafs)
        {
            if (leaf.roomStat.Count > 0)
            {
                for (int i = leaf.roomStat[0].Y; i < leaf.roomStat[0].Y + leaf.roomStat[1].Y; i++)
                {
                    for (int j = leaf.roomStat[0].X; j < leaf.roomStat[0].X + leaf.roomStat[1].X; j++)
                    {
                        map[i, j] = '.';
                        map2[i, j] = '.';
                    }
                }
            }

            if (leaf.halls != null)
            {
                foreach (Point point in leaf.halls)
                {
                    map[point.Y, point.X] = '*';
                    map2[point.Y, point.X] = '*';

                }
            }
        }
    }

    public void PrintMap()
    {
        for (int i = 0; i < MAP_HEIGHT; i++)
        {
            for (int j = 0; j < MAP_WIDTH; j++)
            {
                //if (map[i, j] != map2[i, j])
                Console.Write(map[i, j]);
            }
            Console.Write('\n');
        }
        Console.SetCursorPosition(0, 0);
    }
}

