using UnityEngine;


public class Player : MonoBehaviour {
    Collision col = null;

    void Start() {
        // コリジョンの呼び出し
        this.col = GameManager.collision.PickOut(COL_CATEGORY.PLAYER);
        this.col.range = 50f;
        this.col.hitHandler = this.HitCallback;
        
        // スクリーン座標をコリジョンに通知
        Vector3 scPos = Camera.main.WorldToScreenPoint(this.transform.position);
        this.col.point = scPos;
    }

    void Update() {
        // スクリーン座標をコリジョンに通知
        Vector3 scPos = Camera.main.WorldToScreenPoint(this.transform.position);
        this.col.point = scPos;
    }
    
    /// <summary>
    /// 接触コールバック
    /// </summary>
    /// <param name="atk">影響を与えるコリジョン</param>
    /// <param name="def">影響を受けるコリジョン</param>
    private void HitCallback(Collision atk, Collision def) {
        // atkに自身、defに相手（この場合は敵）が受け渡される
        Debug.Log("PLAYER HIT !!!");

        atk.enable = false;    // 自身のコリジョンの返却
    }
}