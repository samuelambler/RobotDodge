	using System.Numerics;
using SplashKitSDK;

public abstract class Robot
{
	public double X { get; set; }
	public double Y { get; set; }
	private Vector2D Velocity { get; set; }
	public Color MainColor { get; set; }
	private int Width
	{
		get { return 50; }
	}
	private int Height
	{
		get { return 50; }
	}
	public Circle CollisionCircle
	{
		get { return SplashKit.CircleAt(X + (Width / 2), Y + (Height / 2), 20); }
	}

	public Robot(Window gameWindow, Player player)
	{
		const int SPEED = 4;

		if (SplashKit.Rnd() < 0.5)
		{
			X = SplashKit.Rnd(gameWindow.Width);

			if (SplashKit.Rnd() < 0.5)
			{
				Y = -Height;
			}
			else
			{
				Y = gameWindow.Height;
			}
		}
		else
		{
			Y = SplashKit.Rnd(gameWindow.Height);

			if (SplashKit.Rnd() < 0.5)
			{
				X = -Width;
			}
			else
			{
				X = gameWindow.Width;
			}
		}

		Point2D fromPt = new Point2D()
		{
			X = X,
			Y = Y
		};

		Point2D toPt = new Point2D()
		{
			X = player.X,
			Y = player.Y
		};

		Vector2D dir = SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPt, toPt));

		Velocity = SplashKit.VectorMultiply(dir, SPEED);

		MainColor = Color.RandomRGB(200);
	}

	public abstract void Draw();

	public void Update()
	{
		X += Velocity.X;
		Y += Velocity.Y;
	}

	public bool IsOffScreen(Window screen)
	{
		return X < -Width || X > screen.Width || Y < -Height || Y > screen.Height;
	}
}