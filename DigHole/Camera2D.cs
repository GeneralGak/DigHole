using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigHole
{
	public class Camera2D : GameComponent
	{

		private float deltaTime;
		private Vector2 position;
		protected float viewportHeight;
		protected float viewportWidth;


		public Vector2 Position
		{
			get { return position; }
			set { position = value; }
		}
		public float MoveSpeed { get; set; }
		public float Rotation { get; set; }

		public Vector2 Origin { get; set; }

		public float Scale { get; set; }

		public Vector2 ScreenCenter { get; protected set; }

		public Matrix Transform { get; set; }

		public IFocusable Focus { get; set; }


		public Camera2D(Game game, IFocusable Focus) : base(game)
		{
			this.Focus = Focus;
			Initialize();
		}

		public override void Initialize()
		{
			viewportWidth = Game.GraphicsDevice.Viewport.Width;
			viewportHeight = Game.GraphicsDevice.Viewport.Height;

			ScreenCenter = new Vector2(viewportWidth / 2, viewportHeight / 2);
			Scale = 1;
			MoveSpeed = 1.25f;

			base.Initialize();
		}

		public bool IsInView(Vector2 position, Texture2D texture)
		{
			// If the object is not within the horizontal bounds of the screen
			if ((position.X + texture.Width) < (Position.X - Origin.X) || (position.X) > (Position.X + Origin.X))
			{
				return false;
			}

			// If the object is not within the vertical bounds of the screen
			if ((position.Y + texture.Height) < (Position.Y - Origin.Y) || (position.Y) > (Position.Y + Origin.Y))
			{
				return false;
			}

			// In View
			return true;
		}

		public override void Update(GameTime gameTime)
		{

			// TODO: Ask about the function of this.
			// Create the Transform used by any
			// spritebatch process
			Transform = Matrix.Identity *
						Matrix.CreateTranslation(-Position.X, -Position.Y, 0) *
						Matrix.CreateRotationZ(Rotation) *
						Matrix.CreateTranslation(Origin.X, Origin.Y, 0) *
						Matrix.CreateScale(new Vector3(Scale, Scale, Scale));

			Origin = ScreenCenter / Scale;

			// deltaTime based on GameTime
			deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

			position.X += (Focus.Position.X - Position.X) * MoveSpeed * deltaTime;
			position.Y += (Focus.Position.Y - Position.Y) * MoveSpeed * deltaTime;

			base.Update(gameTime);
		}

	}
}
