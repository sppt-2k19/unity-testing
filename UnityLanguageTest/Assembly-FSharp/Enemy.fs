namespace Assembly_FSharp
open System
open UnityEngine
open UnityEngine.SceneManagement

type Enemy() =
    inherit MonoBehaviour()
    [<SerializeField>]
    let mutable moveLeft = false
    [<SerializeField>]
    let mutable moveRight = true
    [<SerializeField>]
    let mutable moveDown = false
    
    member this.Start() =
        ()
        
    member this.Update() =
        //let movement = this.transform.position <- new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z)
        
        if moveLeft = true then
            this.transform.Translate(Vector3.left * Time.deltaTime)
        
        if moveRight = true then
            this.transform.Translate(Vector3.right * Time.deltaTime)
        
        if moveDown = true then
            this.transform.position <- new Vector3(this.transform.position.x, this.transform.position.y - 1.0f , this.transform.position.z)
            moveDown <- false
            
        if this.transform.position.x <= -8.701f then
            moveLeft <- false
            moveRight <- true
            moveDown <- true

        
        if this.transform.position.x >= 8.701f then
            moveRight <- false
            moveLeft <- true
            moveDown <- true
            
        if this.transform.position.y = -3.6f then
            SceneManager.LoadScene("Dead")
            
       
            
            
