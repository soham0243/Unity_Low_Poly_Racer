using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public enum CameraType { Camera_1, Camera_2, Camera_3, Camera_4, Camera_5}
	public CameraType cameraType = CameraType.Camera_1;
	public Transform Target;
	
	public Vector3 offset;
	public Vector3 eulerRotation;
	public float damper;
	
    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = eulerRotation;
		
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 temp_pos, temp_rot, temp_pos1;
        if(Target == null){
			return;
		}
		if(cameraType == CameraType.Camera_1){
			transform.position = Vector3.Lerp(transform.position, Target.position + offset, damper * Time.time);
		}else if(cameraType == CameraType.Camera_2){
			temp_pos = - offset;
			temp_rot = - eulerRotation;
			temp_pos1.x = temp_pos.x * Mathf.Cos(temp_rot.z) * Mathf.Cos(temp_rot.y) + temp_pos.y * (Mathf.Cos(temp_rot.z)*Mathf.Sin(temp_rot.y)*Mathf.Sin(temp_rot.x) - Mathf.Sin(temp_rot.z)*Mathf.Cos(temp_rot.x)) + temp_pos.z * (Mathf.Cos(temp_rot.z)*Mathf.Sin(temp_rot.y)*Mathf.Cos(temp_rot.x) + Mathf.Sin(temp_rot.z)*Mathf.Sin(temp_rot.x));
			temp_pos1.y = temp_pos.x * Mathf.Sin(temp_rot.z) * Mathf.Cos(temp_rot.y) + temp_pos.y * (Mathf.Sin(temp_rot.z)*Mathf.Sin(temp_rot.y)*Mathf.Sin(temp_rot.x) + Mathf.Cos(temp_rot.z)*Mathf.Cos(temp_rot.x)) + temp_pos.z * (Mathf.Sin(temp_rot.z)*Mathf.Sin(temp_rot.y)*Mathf.Cos(temp_rot.x) - Mathf.Cos(temp_rot.z)*Mathf.Sin(temp_rot.x));
			temp_pos1.z = - temp_pos.x * Mathf.Sin(temp_rot.y) + temp_pos.y * Mathf.Cos(temp_rot.y) * Mathf.Sin(temp_rot.x) + temp_pos.z * Mathf.Cos(temp_rot.y) * Mathf.Cos(temp_rot.x);
			
			transform.position = Target.position + temp_pos1;
			transform.LookAt(Target.position);
		}else if(cameraType == CameraType.Camera_3){
			temp_pos = offset;
			temp_rot = eulerRotation;
			temp_pos1.x = temp_pos.x * Mathf.Cos(temp_rot.z) * Mathf.Cos(temp_rot.y) + temp_pos.y * (Mathf.Cos(temp_rot.z)*Mathf.Sin(temp_rot.y)*Mathf.Sin(temp_rot.x) - Mathf.Sin(temp_rot.z)*Mathf.Cos(temp_rot.x)) + temp_pos.z * (Mathf.Cos(temp_rot.z)*Mathf.Sin(temp_rot.y)*Mathf.Cos(temp_rot.x) + Mathf.Sin(temp_rot.z)*Mathf.Sin(temp_rot.x));
			temp_pos1.y = temp_pos.x * Mathf.Sin(temp_rot.z) * Mathf.Cos(temp_rot.y) + temp_pos.y * (Mathf.Sin(temp_rot.z)*Mathf.Sin(temp_rot.y)*Mathf.Sin(temp_rot.x) + Mathf.Cos(temp_rot.z)*Mathf.Cos(temp_rot.x)) + temp_pos.z * (Mathf.Sin(temp_rot.z)*Mathf.Sin(temp_rot.y)*Mathf.Cos(temp_rot.x) - Mathf.Cos(temp_rot.z)*Mathf.Sin(temp_rot.x));
			temp_pos1.z = - temp_pos.x * Mathf.Sin(temp_rot.y) + temp_pos.y * Mathf.Cos(temp_rot.y) * Mathf.Sin(temp_rot.x) + temp_pos.z * Mathf.Cos(temp_rot.y) * Mathf.Cos(temp_rot.x);
			
			transform.position = Target.position + temp_pos1;
			transform.LookAt(Target.position);
		}else if(cameraType == CameraType.Camera_4){
			transform.rotation = Quaternion.Slerp(transform.rotation, Target.rotation, damper * Time.time);
			transform.position = Target.position + new Vector3(0,.7f,0);
		}else if(cameraType == CameraType.Camera_5){
			//transform.position = Target.position + Target.TransformDirection(new Vector3(0,2.5f,-7));
			transform.position = Target.position + Target.rotation * (new Vector3(0,2.5f,-7));
			//temp_pos = new Vector3(0,2.5f,-7);
			//temp_rot = Target.eulerAngles * (Mathf.PI/180);
			//temp_pos1.x = temp_pos.x * Mathf.Cos(temp_rot.z) * Mathf.Cos(temp_rot.y) + temp_pos.y * (Mathf.Cos(temp_rot.z)*Mathf.Sin(temp_rot.y)*Mathf.Sin(temp_rot.x) - Mathf.Sin(temp_rot.z)*Mathf.Cos(temp_rot.x)) + temp_pos.z * (Mathf.Cos(temp_rot.z)*Mathf.Sin(temp_rot.y)*Mathf.Cos(temp_rot.x) + Mathf.Sin(temp_rot.z)*Mathf.Sin(temp_rot.x));
			//temp_pos1.y = temp_pos.x * Mathf.Sin(temp_rot.z) * Mathf.Cos(temp_rot.y) + temp_pos.y * (Mathf.Sin(temp_rot.z)*Mathf.Sin(temp_rot.y)*Mathf.Sin(temp_rot.x) + Mathf.Cos(temp_rot.z)*Mathf.Cos(temp_rot.x)) + temp_pos.z * (Mathf.Sin(temp_rot.z)*Mathf.Sin(temp_rot.y)*Mathf.Cos(temp_rot.x) - Mathf.Cos(temp_rot.z)*Mathf.Sin(temp_rot.x));
			//temp_pos1.z = - temp_pos.x * Mathf.Sin(temp_rot.y) + temp_pos.y * Mathf.Cos(temp_rot.y) * Mathf.Sin(temp_rot.x) + temp_pos.z * Mathf.Cos(temp_rot.y) * Mathf.Cos(temp_rot.x);
			
			//transform.position = Target.position + temp_pos1;
			transform.LookAt(Target.position);
		}else{}
    }
}
