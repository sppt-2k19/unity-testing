namespace Assembly_FSharp
open UnityEngine

type Player() =
    inherit MonoBehaviour()    
    [<SerializeField>]
    let mutable movementSpeed = 20.0f
    [<SerializeField>]
    let mutable bulletSpeed = 20.0f
    [<SerializeField>]
    let mutable rb = null
    [<SerializeField>]
    let mutable bullet = null
    [<SerializeField>]
    let mutable audioData = null
    
    let _onFire = new Event<unit>()
        
    member this.Start() =
        rb = this.GetComponent<Rigidbody2D>()
        
        bullet = this.GetComponent<Rigidbody2D>()
        
        audioData = this.GetComponent<AudioSource>()
        
    member this.Update() = 
        let moveHorizontal = Input.GetAxis("Horizontal")
        let movement = new Vector2(moveHorizontal,0.0f)
        rb.AddForce(movement * movementSpeed)
        
        match rb.transform.position.x with
           | a when a <= -8.701f -> rb.transform.position <- new Vector3(-8.701f, rb.transform.position.y,rb.transform.position.z)
           | a when a >= 8.701f -> rb.transform.position <- new Vector3(8.701f, rb.transform.position.y,rb.transform.position.z)
           | _ -> rb.transform.position <- new Vector3(rb.transform.position.x, rb.transform.position.y,rb.transform.position.z)
        
        let shootAudio =
            if Input.GetKeyDown("space") then
                audioData.Play()
        
        let shootBullet =
            if Input.GetKeyDown("space") then
                let bulletClone = GameObject.Instantiate<Rigidbody2D>(bullet, this.transform.position, this.transform.rotation)
                bulletClone.velocity <- new Vector2(0.0f, bulletSpeed)
                
        
        _onFire.Publish.Add(fun () -> shootAudio)
        _onFire.Publish.Add(fun () -> shootBullet)
        
        
