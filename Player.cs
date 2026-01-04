using System.Linq.Expressions;
using SplashKitSDK;

public class Player
{
	private Bitmap _PlayerBitmap;
	public double X { get; set; }
	public double Y { get; set; }
	public Lives _Lives;
	public bool Quit { get; private set; }
	public SplashKitSDK.Timer myTimer;
	public string Score
	{
		get
		{
			return Convert.ToString(Math.Round(Convert.ToDecimal(myTimer.Ticks) / 1000, 0));
		}
	}
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

		_Lives = new Lives(5);
		Quit = false;

		myTimer = new SplashKitSDK.Timer("My Timer");
		myTimer.Start();
	}

	public void Draw()
	{
		SplashKit.DrawBitmap(_PlayerBitmap, X, Y);
		_Lives.Draw();
		SplashKit.DrawText(this.Score, Color.Black, SplashKit.LoadFont("impact", "ARLRDBD.TTF"), 20, 750, 20);
	}

	public void HandleInput()
	{
		int SPEED = 5;

		if (SplashKit.KeyDown(KeyCode.LeftShiftKey))
		{
			SPEED = 10;
		}

		if (SplashKit.KeyDown(KeyCode.WKey))
		{
			Y -= SPEED;
		}

		if (SplashKit.KeyDown(KeyCode.SKey))
		{
			Y += SPEED;
		}

		if (SplashKit.KeyDown(KeyCode.AKey))
		{
			X -= SPEED;
		}

		if (SplashKit.KeyDown(KeyCode.DKey))
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

	public bool CollidedWidth(Robot other)
	{
		if (_PlayerBitmap.CircleCollision(X, Y, other.CollisionCircle))
		{
			_Lives.numLives--;
			if (_Lives.numLives == 0)
			{
				Quit = true;
			}
			return true;
		}
		return false;
	}
}