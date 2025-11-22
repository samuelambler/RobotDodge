using SplashKitSDK;

public class Player
{
	private Bitmap _PlayerBitmap;
	public double X { get; set; }
	public double Y { get; set; }
	public bool Quit { get; private set; }
	public int Width
	{
		get
		{
			return _PlayerBitmap.Width;
		}
	}

	public int Height
	{
		get
		{
			return _PlayerBitmap.Height;
		}
	}

	public Player(string name, string fileLocation, Window gameWindow)
	{
		_PlayerBitmap = SplashKit.LoadBitmap(name, fileLocation);
		X = (gameWindow.Width - Width) / 2;
		Y = (gameWindow.Height - Height) / 2;
		Quit = false;
	}

	public void Draw()
	{
		SplashKit.DrawBitmap(_PlayerBitmap, X, Y);
	}

	public void HandleInput()
	{
		int SPEED = 5;

		if (SplashKit.KeyDown(KeyCode.LeftShiftKey))
		{
			SPEED = 10;
		}

		if (SplashKit.KeyDown(KeyCode.UpKey))
		{
			Y -= SPEED;
		}

		if (SplashKit.KeyDown(KeyCode.DownKey))
		{
			Y += SPEED;
		}

		if (SplashKit.KeyDown(KeyCode.LeftKey))
		{
			X -= SPEED;
		}

		if (SplashKit.KeyDown(KeyCode.RightKey))
		{
			X += SPEED;
		}

		if (SplashKit.KeyTyped(KeyCode.EscapeKey))
		{
			Quit = true;
		}
	}

	public void StayOnWindow(Window limit)
	{
		const int GAP = 10;

		if (X < GAP)
		{
			X = GAP;
		}

		if (X + Width > limit.Width - GAP)
		{
			X = limit.Width - Width - GAP;
		}

		if (Y < GAP)
		{
			Y = GAP;
		}

		if (Y + Height > limit.Height - GAP)
		{
			Y = limit.Height - Height - GAP;
		}
	}
}