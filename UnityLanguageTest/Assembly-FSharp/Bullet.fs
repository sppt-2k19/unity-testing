namespace Assembly_FSharp
open UnityEngine


type Bullet() =
    inherit MonoBehaviour()
    
    
    [<SerializeField>]
    let mutable bulletRigidbody:Rigidbody2D = null
    
    [<SerializeField>]
    let mutable Speed = 10000.0f
    
    member this.Start() =
        GameObject.Destroy(this.gameObject, 2.0f)
        
    member this.Update() =
        bulletRigidbody.AddForce(new Vector2(0.0f, Speed * Time.deltaTime))
        
        
    member this.OnCollisionEnter2D(collision:Collision2D) =
        GameObject.Destroy(this.gameObject)
