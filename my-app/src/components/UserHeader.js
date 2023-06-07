import React,{Fragment,useEffect,useState} from "react";
import { Link,useNavigate } from "react-router-dom";



const UserHeader = () => {
    const history = useNavigate();
    const [username, setUserName] = useState("");
    useEffect(() =>{
        setUserName(localStorage.getItem("username"));

    },[]);

    const logout = (e)=>{

        e.preventDefault();
        localStorage.removeItem("username");
        history.push("/");
    };
  return (
    <div>
      








    </div>
  )
}

export default UserHeader