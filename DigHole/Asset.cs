using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DigHole
{
	public static class Asset
	{

		public static Texture2D PlayerSprite;

		public static void LoadContent(ContentManager content)
		{
			PlayerSprite = content.Load<Texture2D>("pixelpeople-jobs-079");
		}

	}
}
