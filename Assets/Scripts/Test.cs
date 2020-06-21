using UnityEngine;

public class Test : MonoBehaviour
{
	public static Test singleton;    

	private void Awake()
	{
		if(!(singleton is null) && singleton != this) 
			Destroy(this);
		singleton = this;
	}
};