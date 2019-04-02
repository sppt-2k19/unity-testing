namespace Assembly_FSharp
open UnityEngine
open UnityEngine.SceneManagement

type Player() =
    inherit MonoBehaviour()    

    [<SerializeField>]
    let mutable Speed = 100.0f
    
    [<SerializeField>]
    let mutable Swerve = 100.0f
   
    [<SerializeField>]
    let mutable BulletPrefab:GameObject = null
    
    let event = new Event<unit>()
    
    
    member this.Start() =
        let shootSound = this.GetComponent<AudioSource>()
        event.Publish.Add (fun e -> shootSound.Play())
        
        event.Publish.Add (fun e ->
            let bulletPosition = new Vector3(this.transform.position.x, this.transform.position.y + 0.8f, this.transform.position.z)
            GameObject.Instantiate<GameObject>(BulletPrefab, bulletPosition, Quaternion.identity) |> ignore)
        
    member this.Update() =
        let horizontal = Input.GetAxis("Horizontal")
        let rigidbody = this.GetComponent<Rigidbody2D>()
        rigidbody.AddForce(new Vector2(horizontal * Time.deltaTime * Speed, 0.0f))
        
        this.transform.rotation.Set(0.0f, Swerve * horizontal, 0.0f, 0.0f)
        
        if Input.GetButtonDown("Fire1") then
            event.Trigger()
        

    member this.OnCollisionEnter2D(collision:Collision2D) =
        match collision.gameObject.tag with
        | "Enemy" -> SceneManager.LoadScene("Dead")
        | _ -> ()