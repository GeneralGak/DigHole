using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigHole
{
	public class Room : Environment
	{

		private List<GameObject> roomObjects = new List<GameObject>();

		public List<GameObject> RoomObjects
		{
			get { return roomObjects; }
			set { roomObjects = value; }
		}

	}
}
