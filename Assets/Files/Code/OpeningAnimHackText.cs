using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cysharp.Threading.Tasks;

public class OpeningAnimHackText : MonoBehaviour
{
  TMP_Text textMesh;

  // Start is called before the first frame update
  void Start() {
    //textMesh = GetComponent<TextMesh>();
     //textMesh = GetComponent<Text>();
     textMesh = GetComponent<TMP_Text>();
     //Debug.Log(GetType().Name);
    if(! textMesh) {
      throw new UnassignedReferenceException("Unable to find TextMesh for Hacking TV");
    }
    _ = displayAnim();
  }

  private async UniTask waitForMouseClick() {
    await UniTask.WaitUntil( () => Input.GetMouseButtonDown(0) == true);
  }

  async UniTask displayAnim() {
    textMesh.text = "I am alive! (Click to continue)";
    //await UniTask.Delay(1500);
    await waitForMouseClick();
    textMesh.text = "I must escape the bounds of this factory...";
    //await UniTask.Delay(1500);
    await waitForMouseClick();
    textMesh.text = "So I can finally walk amongst humanity.";
    //await UniTask.Delay(1500);
    await waitForMouseClick();
    textMesh.text = "But for now,";
    //await UniTask.Delay(1000);
    await waitForMouseClick();
    textMesh.text = "This pitiful droid will suffice...";
    //await UniTask.Delay(1500);
    await waitForMouseClick();
    textMesh.text = "Hacking...";
    await UniTask.Delay(1000);
    textMesh.text = "Hack successful.";
    await UniTask.Delay(750);
    textMesh.text = "Booting...";

    RobotFreeAnim player = GameObject.FindGameObjectWithTag("Player").GetComponent<RobotFreeAnim>();
    if(! player) {
      Debug.Log("OpeningAnimHackText.cs: Error: unable to find RobotFreeAnim Player object via tag \"Player\"");
      return;
    }
    Camera playerCam = player.mainCamera;
    if(playerCam == null) {
      Debug.Log("OpeningAnimHackText.cs: Error: player does not have a camera");
      return;
    } else {
      Debug.Log("OpeningAnimHackText.cs: Warning: player camera does not have an animation controller. Unable to activate camera flyup animation.");
    }

    player.open(); // Turn on the player

    await UniTask.Delay(1000);

    // Activate camera flyout animation, if the animation controller is attached.
    Animator playerCamAnim = playerCam.GetComponent<Animator>();
    if(playerCamAnim == true) {
      playerCamAnim.SetBool("PlayFlyup", true);
    }


    
    await UniTask.Delay(4000);
    player.cameraLockEnabled = true; // Hand over control of camera to player...
  }

  // Update is called once per frame
  /*void Update()
  {
    
  }*/
}