// using SplashKitSDK;

// public class Roundy : Robot
// {
// 	public Roundy(Window gameWindow, Player player) : base(gameWindow, player)
// 	{

// 	}

// 	public override void Draw()
// 	{
// 		double leftX, midX, rightX;
// 		double midY, eyeY, mouthY;

// 		leftX = X + 17;
// 		midX = X + 25;
// 		rightX = X + 33;

// 		midY = Y + 25;
// 		eyeY = Y + 20;
// 		mouthY = Y + 35;

// 		SplashKit.FillCircle(Color.White, midX, midY, 25);
// 		SplashKit.DrawCircle(Color.Gray, midX, midY, 25);
// 		SplashKit.FillCircle(MainColor, leftX, eyeY, 5);
// 		SplashKit.FillCircle(MainColor, rightX, eyeY, 5);
// 		SplashKit.FillEllipse(Color.Gray, X, eyeY, 50, 30);
// 		SplashKit.DrawLine(Color.Black, X, mouthY, X + 50, Y + 35);
// 	}
// }