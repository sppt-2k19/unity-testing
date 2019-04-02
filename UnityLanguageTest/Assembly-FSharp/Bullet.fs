namespace Assembly_FSharp
open UnityEngine

type Bullet() =
    inherit MonoBehaviour()
    
    let _onDestroy = new Event<unit>()
    
    member this.Start() =
        ()
        
    member this.Update() =
        ()
    
    member this.OnCollisionEnter2D(unit:Collision2D) =
        let onCollide =
            if unit.gameObject.CompareTag("Enemy") then
                GameObject.Destroy(unit.gameObject)
                GameObject.Destroy(this.gameObject)
                    
        _onDestroy.Publish.Add(fun () -> onCollide)