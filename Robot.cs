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

public class Spiky : Robot
{

	public Spiky(Window gameWindow, Player player) : base(gameWindow, player)
	{

	}

	public override void Draw()
	{
		double leftX, midX, rightX;
		double eyeY, mouthY;

		leftX = X + 24;
		midX = X + 30;
		rightX = X + 36;

		eyeY = Y + 30;
		mouthY = Y + 42;

		SplashKit.FillTriangle(Color.Gray, X, Y + 60, X + 60, Y + 60, midX, Y);
		SplashKit.FillCircle(MainColor, leftX, eyeY, 5);
		SplashKit.FillCircle(MainColor, rightX, eyeY, 5);
		SplashKit.FillRectangle(MainColor, X + 18, mouthY, 24, 12);
		SplashKit.FillRectangle(MainColor, X + 22, mouthY + 3, 16, 6);
	}
}

public class Roundy : Robot
{
	public Roundy(Window gameWindow, Player player) : base(gameWindow, player)
	{

	}

	public override void Draw()
	{
		double leftX, midX, rightX;
		double midY, eyeY, mouthY;

		leftX = X + 17;
		midX = X + 25;
		rightX = X + 33;

		midY = Y + 25;
		eyeY = Y + 20;
		mouthY = Y + 35;

		SplashKit.FillCircle(Color.White, midX, midY, 25);
		SplashKit.DrawCircle(Color.Gray, midX, midY, 25);
		SplashKit.FillCircle(MainColor, leftX, eyeY, 5);
		SplashKit.FillCircle(MainColor, rightX, eyeY, 5);
		SplashKit.FillEllipse(Color.Gray, X, eyeY, 50, 30);
		SplashKit.DrawLine(Color.Black, X, mouthY, X + 50, Y + 35);
	}
}

public class Boxy : Robot
{
	
	public Boxy(Window gameWindow, Player player) : base(gameWindow, player)
	{
		
	}

		public override void Draw()
	{
		double leftX, rightX;
		double eyeY, mouthY;

		leftX = X + 12;
		rightX = X + 27;
		eyeY = Y + 10;
		mouthY = Y + 30;

		SplashKit.FillRectangle(Color.Gray, X, Y, 50, 50);
		SplashKit.FillRectangle(MainColor, leftX, eyeY, 10, 10);
		SplashKit.FillRectangle(MainColor, rightX, eyeY, 10, 10);
		SplashKit.FillRectangle(MainColor, leftX, mouthY, 25, 10);
		SplashKit.FillRectangle(MainColor, leftX + 2, mouthY + 2, 21, 6);
	}
}