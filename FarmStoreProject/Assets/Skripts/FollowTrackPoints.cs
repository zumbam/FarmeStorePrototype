using UnityEngine;
using System.Collections;


public class FollowTrackPoints : MonoBehaviour {


	enum Place{
		Gate ,Spring,Tarvern
	}



	[SerializeField]
	float velocity = 1.5f;
	[SerializeField]
	GameObject [] trackFromGate;
	[SerializeField]
	GameObject [] trackToTavern;


	private GameObject [] currentTrack;
	private  int lastTrackIndex;
	private Place currentPlace ;


	bool OnTrack  = false;


	// Use this for initialization
	void Start () {

		 
		setCurrentPlace (Place.Spring);
		transform.position = currentTrack [lastTrackIndex++].transform.position;

	
	}
	
	// Update is called once per frame
	void Update () {


		//check if the track is walked 
		if (lastTrackIndex < currentTrack.Length) {

			float deltaT = Time.deltaTime;
			float deltaDistance = deltaT * velocity;
			Vector3 currentPos = this.transform.position;
			Vector3 nextPos = currentTrack [lastTrackIndex].transform.position;
			float dist = Vector3.Distance (currentPos, nextPos);
			float distanceInPercentage = deltaDistance / dist;
			Vector3 interpolatetPos = Vector3.Lerp (currentPos, nextPos, distanceInPercentage);

			Debug.DrawLine (currentPos, interpolatetPos);
			if (interpolatetPos == nextPos) {
				lastTrackIndex++;
			}

			this.transform.position = interpolatetPos;
			Debug.Log (interpolatetPos);
			

		} else {
			OnTrack = false;
		}




	}

	void setCurrentPlace(Place place){

		if (place == currentPlace) {
			Debug.Log ("cannot change to same place");
			return;
		}

		if (currentPlace != Place.Spring) {
			switch(currentPlace){
			case Place.Gate:
				currentTrack = reverseTrack (trackFromGate);
				currentPlace  = Place.Gate;

				break;
			}

			OnTrack = true;
		


		}


	}


	float calcTrackSize(GameObject [] track){

		float length =0;

		for (int i = 0 ; i< track.Length-1;i++ ){
			length += Vector3.Distance(track[i].transform.position , track[i+1].transform.position);

		}
		return length;

	}

	GameObject [] reverseTrack(GameObject [] track){


		GameObject [] reverseTrack = new GameObject[track.Length];
		for (int i = 0; i <track.Length;  i++) {
			reverseTrack [i] = track [track.Length - 1 - i];


		}
		Debug.Log (reverseTrack);
		return reverseTrack;

	}
	public bool onTrack{
		get{return OnTrack;}
	}

}



