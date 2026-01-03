using SplashKitSDK;

public class Lives
{
	private Bitmap _Heart; 
	// public double windowOffsetX { get; set; }
	// public double windowOffsetY { get; set; }
	public int numLives { get; set; }
	public int Width
	{
		get
		{
			return _Heart.Width;
		}
	}
	public int Height
	{
		get
		{
			return _Heart.Height;
		}
	}

	public Lives(int startLives)
	{
		// image attributed to "Freepik" from Flaticon.com
		// https://www.flaticon.com/free-icon/heart_465271
		_Heart = SplashKit.LoadBitmap("heart", "heart.png");
		numLives = startLives;
	}

	public void Draw()
	{
		const int offset = 10;
		for (int i = 0; i < numLives; i++)
		{
			SplashKit.DrawBitmap(_Heart, offset + (i * offset) + (i * Width), offset);
		}
	}
}