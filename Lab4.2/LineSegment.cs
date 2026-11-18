internal class LineSegment
{
    private double _x;
    private double _y;

    public double X
    {
        get { return _x; }
        set { _x = value; }
    }

    public double Y
    {
        get { return _y; }
        set { _y = value; }
    }

    public LineSegment(double x, double y)
    {
        _x = x;
        _y = y;
    }

    public bool Intersects(LineSegment other)
    {
        double min1 = _x < _y ? _x : _y;
        double max1 = _x > _y ? _x : _y;
        double min2 = other._x < other._y ? other._x : other._y;
        double max2 = other._x > other._y ? other._x : other._y;

        return max1 >= min2 && max2 >= min1;
    }

    public static double operator !(LineSegment lineSegment)
    {
        return Math.Abs(lineSegment._y - lineSegment._x);
    }

    public static LineSegment operator ++(LineSegment lineSegment)
    {
        return new LineSegment(lineSegment._x - 1, lineSegment._y + 1);
    }

    public static implicit operator int(LineSegment lineSegment)
    {
        return (int)lineSegment._x;
    }

    public static explicit operator double(LineSegment lineSegment)
    {
        return lineSegment._y;
    }

    public static LineSegment operator -(LineSegment lineSegment, int value)
    {
        return new LineSegment(lineSegment._x - value, lineSegment._y);
    }

    public static LineSegment operator -(int value, LineSegment lineSegment)
    {
        return new LineSegment(lineSegment._x, lineSegment._y - value);
    }

    public static bool operator <(LineSegment firstSegment, LineSegment secondSegment)
    {
        return firstSegment.Intersects(secondSegment);
    }

    public static bool operator >(LineSegment firstSegment, LineSegment secondSegment)
    {
        return !firstSegment.Intersects(secondSegment);
    }

    public override string ToString()
    {
        return string.Format("Отрезок [{0}; {1}]", _x, _y);
    }
}