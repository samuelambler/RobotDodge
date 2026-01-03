using SplashKitSDK;

public class Bullet
{
	private double _X;
	private double _Y;
	private Vector2D _Velocity;
	private const int RADIUS = 5;
	private const int SPEED = 10;

	public Bullet(double startX, double startY, Point2D target)
	{
		_X = startX;
		_Y = startY;
		Point2D origin = new Point2D() { X = _X, Y = _Y };
		Vector2D dir = SplashKit.UnitVector(SplashKit.VectorPointToPoint(origin, target));
		_Velocity = SplashKit.VectorMultiply(dir, SPEED);
	}

	public void Update()
	{
		_X += _Velocity.X;
		_Y += _Velocity.Y;
	}

	public void Draw()
	{
		SplashKit.FillCircle(Color.Black, _X, _Y, RADIUS);
	}

	public bool IsOffScreen(Window screen)
	{
		return _X < -RADIUS || _X > screen.Width + RADIUS || _Y < -RADIUS || _Y > screen.Height + RADIUS;
	}

	public Circle CollisionCircle
	{
		get { return SplashKit.CircleAt(_X, _Y, RADIUS); }
	}
}