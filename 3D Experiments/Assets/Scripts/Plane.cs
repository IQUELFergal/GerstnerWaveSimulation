using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Plane : MonoBehaviour
{
	private Mesh mesh;

	public bool center = true;
	public Vector2 size = new Vector2(1, 1);
	public int resolutionX = 1;
	public int resolutionY = 1;

	/// <summary>
	/// called when the script is loaded or a value is changed in the inspector
	/// </summary>
	private void OnValidate()
	{
		UpdateMesh();
	}

	/// <summary>
	/// ensure that data is valid (ex : size is positive)
	/// </summary>
	private void ValidateData()
	{
		if (mesh == null)
		{
			if (gameObject.GetComponent<MeshFilter>().sharedMesh == null)
				gameObject.GetComponent<MeshFilter>().sharedMesh = new Mesh();
			mesh = gameObject.GetComponent<MeshFilter>().sharedMesh;
			mesh.name = "Procedural Plane";
		}

		if (size.x < 0.1f)
			size.x = 0.1f;
		if (size.y < 0.1f)
			size.y = 0.1f;

		resolutionX = Mathf.Clamp(resolutionX, 1, 250);
		resolutionY = Mathf.Clamp(resolutionY, 1, 250);
	}

	/// <summary>
	/// reconstruct mesh based on size and resolution
	/// </summary>
	public void UpdateMesh()
	{
		ValidateData();

		Vector3[] vertices = new Vector3[(resolutionX + 1) * (resolutionY + 1)];
		Vector2[] uv = new Vector2[vertices.Length];
		Vector3[] normals = new Vector3[vertices.Length];
		int[] tris = new int[resolutionX * resolutionY * 6];

		for (int i = 0, y = 0; y <= resolutionY; y++)
		{
			for (int x = 0; x <= resolutionX; x++)
			{
				vertices[i] = new Vector3(x * size.x / resolutionX, 0, y * size.y / resolutionY);
				if (center)
					vertices[i] -= new Vector3(size.x / 2, 0, size.y / 2);
				uv[i] = new Vector2((float)x / resolutionX, (float)y / resolutionY);
				normals[i++] = Vector3.up;
			}
		}

		for (int i = 0, y = 0; y < resolutionY; y++)
		{
			for (int x = 0; x < resolutionX; x++)
			{
				tris[i + 5] =
				tris[i] = y * (resolutionX + 1) + x;
				tris[i + 1] = (y + 1) * (resolutionX + 1) + x;
				tris[i + 2] =
				tris[i + 3] = (y + 1) * (resolutionX + 1) + x + 1;
				tris[i + 4] = y * (resolutionX + 1) + x + 1;
				i += 6;
			}
		}

		mesh.Clear();
		mesh.vertices = vertices;
		mesh.uv = uv;
		mesh.normals = normals;
		mesh.SetIndices(tris, MeshTopology.Triangles, 0);
		mesh.RecalculateBounds();
	}
}