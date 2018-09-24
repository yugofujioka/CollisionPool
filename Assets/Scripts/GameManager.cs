using UnityEngine;

public class GameManager : MonoBehaviour {
    public static CollisionPool collision;

    void Awake() {
        GameManager.collision = new CollisionPool();
        GameManager.collision.Initialize();

        // 1m = 1pixの位置にカメラを移動させる
        Camera cam = Camera.main;
        float tanFOV = Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
        float dist = Screen.height * 0.5f / tanFOV;
        cam.transform.localPosition = new Vector3(0f, 0f, -dist);
    }

    void Update() {
        float elapsedTime = Time.deltaTime;

        // コリジョンの更新（判定）
        GameManager.collision.Proc(elapsedTime);
    }
}
