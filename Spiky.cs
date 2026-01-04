// using SplashKitSDK;

// public class Spiky : Robot
// {

// 	public Spiky(Window gameWindow, Player player) : base(gameWindow, player)
// 	{

// 	}

// 	public override void Draw()
// 	{
// 		double leftX, midX, rightX;
// 		double eyeY, mouthY;

// 		leftX = X + 24;
// 		midX = X + 30;
// 		rightX = X + 36;

// 		eyeY = Y + 30;
// 		mouthY = Y + 42;

// 		SplashKit.FillTriangle(Color.Gray, X, Y + 60, X + 60, Y + 60, midX, Y);
// 		SplashKit.FillCircle(MainColor, leftX, eyeY, 5);
// 		SplashKit.FillCircle(MainColor, rightX, eyeY, 5);
// 		SplashKit.FillRectangle(MainColor, X + 18, mouthY, 24, 12);
// 		SplashKit.FillRectangle(MainColor, X + 22, mouthY + 3, 16, 6);
// 	}
// }