using SplashKitSDK;

public class Robot
{
	public double X { get; set; }
	public double Y { get; set; }
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

	public Robot(Window gameWindow)
	{
		const int GAP = 10;

		X = SplashKit.Rnd(gameWindow.Width - Width - GAP);
		Y = SplashKit.Rnd(gameWindow.Height - Height - GAP);

		MainColor = Color.RandomRGB(200);
	}

	public void Draw()
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