using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigHole
{
	public abstract class Environment
	{

		protected List<GameObject> gameObjects = new List<GameObject>();

		public List<GameObject> GameObjects
		{
			get { return gameObjects; }
			set { gameObjects = value; }
		}


		/// <summary>
		/// Add an object to a room or level
		/// </summary>
		/// <param name="gameObject">The object to add</param>
		public void Add(GameObject gameObject)
		{
			if (gameObject != null)
			{
				GameObjects.Add(gameObject);
			}
		}

		/// <summary>
		/// Remove an object from a room or level
		/// </summary>
		/// <param name="gameObject">The object to remove</param>
		public void Remove(GameObject gameObject)
		{
			if (gameObject != null)
			{
				GameObjects.Remove(gameObject);
			}
		}

	}
}
