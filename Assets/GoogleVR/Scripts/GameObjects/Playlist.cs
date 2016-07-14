﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Playlist : MonoBehaviour {

	// hardcoded list of movies for now
	private string[] movieFilenames = new string[3] {
		"39851_1_sciencetake-humanoid_wg_480p.mp4",
		"EasyMovieTexture.mp4",
		"ed_1024_512kb.mp4"
	};

	private string[] movieThumbnails = new string[3] {
		"24APPRAISAL2-videoSixteenByNine1050-v2",
		"13take_promo-videoSixteenByNine1050",
		"out-there-juno-videoSixteenByNine1050"
	};

	// the game objects
	//public List<GameObject> thumbnailObjects = new List<GameObject> ();

	// thumbnail plane
	public GameObject thumbnailPrefab;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < movieFilenames.Length; i++) {
			// initialize the thumbnail gameobject from the prefab
			GameObject thumbnailObj = (GameObject) Instantiate(thumbnailPrefab);
			// set the grid as the parent of the thumbnail
			thumbnailObj.transform.SetParent(gameObject.transform);
			// calculate coordinates of each thumbnail (3 columns)
			int x = 2*(i%3 - 2);
			int y = 5;
			int z = 2 * (i / 3) - 2;
			// set the coordinates relative to parent
			thumbnailObj.transform.localPosition = new Vector3(x, y, z);
			thumbnailObj.transform.localRotation = Quaternion.identity;
			// flip the thumbnail
			Vector3 newScale = thumbnailObj.transform.localScale;
			newScale.z *= -1;
			thumbnailObj.transform.localScale = newScale;
			// add thumbnail as texture
			Material thumbnailImage = GetTextureFromPath(movieThumbnails[i]);
			thumbnailObj.GetComponent<MeshRenderer>().material = thumbnailImage;
			// add thumbnail data
			Thumbnail thumbnail = thumbnailObj.GetComponent<Thumbnail> ();
			thumbnail.movieFileName = movieFilenames [i];

			//thumbnailObjects.Add (thumbnailObj);
		}
	}

	private Material GetTextureFromPath (string path)
	{
		return (Material)Resources.Load(path, typeof(Material));
	}

	// Update is called once per frame
	void Update () {
	
	}
}
