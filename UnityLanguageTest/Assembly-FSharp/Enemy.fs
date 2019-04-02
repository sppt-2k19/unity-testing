namespace Assembly_FSharp
open System
open UnityEngine

type Enemy() =
    inherit MonoBehaviour()
    
    static let mutable movingLeft = true
    static let mutable fromTop = 0
            
    static let mutable lastWallHit = DateTime.MinValue
    static let _wallHit = new Event<unit>()
    static let WallHit = _wallHit.Publish
    
    let mutable dead = false
    
    static let _enemyDied = new Event<unit>()
    static member EnemyDied = _enemyDied.Publish
    
    
    member this.handleWallHit = Handler<unit>(fun _ e ->
        if not dead then
            this.transform.Translate(Vector3.down * 0.7f))
    
    member this.Start() =
        WallHit.AddHandler this.handleWallHit
        
    member this.Update() =
        match movingLeft with
        | true -> this.transform.Translate(Vector3.left * 1.5f * Time.deltaTime)
        | false -> this.transform.Translate(Vector3.right * 1.5f * Time.deltaTime)
        

    member this.OnCollisionEnter2D(collision:Collision2D) =
        match collision.gameObject.tag with
        | "Bullet" ->
            dead <- true
            WallHit.RemoveHandler this.handleWallHit
            GameObject.Destroy(this.gameObject)
            _enemyDied.Trigger()
            
        | "Wall" ->
            if DateTime.UtcNow.Subtract(lastWallHit).TotalMilliseconds > 800.0 then 
                lastWallHit <- DateTime.UtcNow
                movingLeft <- not movingLeft
                _wallHit.Trigger()
                
        | _ -> ()
            
        