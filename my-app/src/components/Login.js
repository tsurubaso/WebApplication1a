import React, { useState } from "react";
import axios from "axios";
import "../App.css";

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleLogin = (e) => {
    e.preventDefault();
    const url = `https://localhost:7039/api/Registration/Login`;
    const data = {
      Email: email,
      Password: password,
      Name: '',
      PhoneNo: '',
    };

    console.log(data);
    axios
      .post(url, data)
      .then((result) => {
        console.log("Result: " + result);
        clear();
        const dt = result.data;
        alert(dt.statusMessage);
        console.log(dt);
      })
      .catch((err) => {
        console.error(err);
      });
  };

  const handleRegistration = (e) => {


    e.preventDefault();
    // Perform login logic
    
    // Redirect to a new URL
    window.location.href = "./registration";



  }

  const clear = () => {
    setEmail("");
    setPassword("");
  };

  return (
    <div>
      <section className="vh-100">
        <div className="container py-5 h-100">
          <div className="row d-flex align-items-center justify-content-center h-100">
            <div className="col-md-8 col-lg-7 col-xl-6">
              <img
                src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/draw2.svg"
                className="img-fluid"
                alt="Phone "
              ></img>
            </div>
            <div className="col-md-7 col-lg-5 col-xl-5 offset-xl-1">
              <form>
                <div className="form-outline mb-4">
                  <input
                    type="email"
                    id="form1Example13"
                    className="form-control form-control-lg"
                    onChange={(e) => setEmail(e.target.value)}
                  />
                  <label className="form-label" for="form1Example13">
                    Email address
                  </label>
                </div>

                <div className="form-outline mb-4">
                  <input
                    type="password"
                    id="form1Example23"
                    className="form-control form-control-lg"
                    onChange={(e) => setPassword(e.target.value)}
                  />
                  <label className="form-label" for="form1Example23">
                    Password
                  </label>
                </div>

                <div className="d-flex justify-content-around align-items-center mb-4">
                  <div className="form-check">
                    <input
                      className="form-check-input"
                      type="checkbox"
                      value=""
                      id="form1Example3"
                      checked
                    />
                    <label className="form-check-label" for="form1Example3">
                      {" "}
                      Remember me{" "}
                    </label>
                  </div>
                  <a href="#!">Forgot password?</a>
                </div>

                <button
                  type="submit"
                  className="btn btn-primary btn-lg btn-block full-width-button "
                  onClick={(e) => handleLogin(e)}
                >
                  Sign in
                </button>

                <div className="divider d-flex align-items-center my-4">
                  <p className="text-center fw-bold mx-3 mb-0 text-muted">OR</p>
                </div>

                <a
                  className="btn btn-primary btn-lg btn-block"
                  style={{ backgroundColor: "#3b5998", width: "50%" }}
                  href="#!"
                  role="button"
                >
                  <i className="fab fa-facebook-f me-2"></i>Continue with
                  Facebook
                </a>
                <a
                  className="btn btn-primary btn-lg btn-block"
                  style={{ backgroundColor: "#55acee", width: "50%" }}
                  href="#!"
                  role="button"
                >
                  <i className="fab fa-twitter me-2"></i>Continue with Twitter
                </a>
                <div className="divider d-flex align-items-center my-1">
                </div>
                <button
                  type="submit"
                  className="btn btn-primary btn-lg btn-block full-width-button "
                  onClick={(e) =>handleRegistration(e)}
                >
                  Not registered yet
                </button>
              </form>
            </div>
          </div>
        </div>
      </section>
    </div>
  );
};

export default Login;
