using System;

namespace BundtEngine
{
	class Program
    {
		static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

			var gameObject = CreateGameObject();

			var engine = new EngineWrapper(gameObject);

			engine.Start();
		}

		static GameObject CreateGameObject()
		{
			var vertices = new Vector3[] {
				new Vector3(-0.5f, -0.5f, 0.0f),
				new Vector3(0.5f, -0.5f, 0.0f),
				new Vector3(0.5f, 0.5f, 0.0f),
				new Vector3(-0.5f, 0.5f, 0.0f),
				new Vector3(-0.5f, -0.5f, -0.5f),
				new Vector3(0.5f, -0.5f, -0.5f),
				new Vector3(0.5f, 0.5f, -0.5f),
				new Vector3(-0.5f, 0.5f, -0.5f)
			};

			var indices = new UInt32[] {
				0, 1, 2, 2, 3, 0,
				4, 5, 6, 6, 7, 4
			};

			var colors = new Vector3[] {
				Color.Blue,
				Color.Purple,
				Color.Red,
				Color.Green,
				Color.Red,
				Color.Green,
				Color.Blue,
				Color.Purple
			};

			var texCoords = new Vector2[] {
				new Vector2(0.0f, 0.0f),
				new Vector2(1.0f, 0.0f),
				new Vector2(1.0f, 1.0f),
				new Vector2(0.0f, 1.0f),
				new Vector2(1.0f, 1.0f),
				new Vector2(0.0f, 1.0f),
				new Vector2(0.0f, 0.0f),
				new Vector2(1.0f, 0.0f)
			};

			return new GameObject(vertices, indices, colors, texCoords);
		}
	}
}