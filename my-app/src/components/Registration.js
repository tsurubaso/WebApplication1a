import React, { useState } from "react";
import axios from "axios";

const Registration = () => {
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [phoneNo, setPhoneNo] = useState("");

  const handleSave = (e) => {
    e.preventDefault();

    const url = "https://localhost:7039/api/Registration/Registration";
    const data = {
      Name: name,
      Email: email,
      Password: password,
      PhoneNo: phoneNo,
    };

    axios
      .post(url, data)
      .then((result) => {
        const dt = result.data;
      })
      .catch((err) => {
        console.error(err);
      });

    return (
      <section className="h-100 bg-dark">
        <div className="container py-5 h-100">
          <div className="row d-flex justify-content-center align-items-center h-100">
            <div className="col">
              <div className="card card-registration my-4">
                <div className="row g-0">
                  <div className="col-xl-6 d-none d-xl-block">
                    <img
                      src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-registration/img4.webp"
                      alt="Sample "
                      className="img-fluid"
                    />
                  </div>
                  <div className="col-xl-6">
                    <div className="card-body p-md-5 text-black">
                      <h3 className="mb-5 text-uppercase">
                        Student registration form
                      </h3>

                      <div className="row">
                        <div className="form-outline mb-4">
                          <div className="form-outline">
                            <input
                              type="text"
                              id="form3Example1m"
                              className="form-control form-control-lg"
                              onChange={(e) => setName(e.target.value)}
                            />
                            <label className="form-label" for="form3Example1m">
                              Name
                            </label>
                          </div>
                        </div>
                      </div>

                      <div className="form-outline mb-4">
                        <input
                          type="text"
                          id="form3Example8"
                          className="form-control form-control-lg"
                          onChange={(e) => setEmail(e.target.value)}
                        />
                        <label className="form-label" for="form3Example8">
                          Email
                        </label>
                      </div>

                      <div className="form-outline mb-4">
                        <input
                          type="text"
                          id="form3Example90"
                          className="form-control form-control-lg"
                          onChange={(e) => setPassword(e.target.value)}
                        />
                        <label className="form-label" for="form3Example90">
                          Password
                        </label>
                      </div>

                      <div className="form-outline mb-4">
                        <input
                          type="text"
                          id="form3Example99"
                          className="form-control form-control-lg"
                          onChange={(e) => setPhoneNo(e.target.value)}
                        />
                        <label className="form-label" for="form3Example99">
                          Phone Number
                        </label>
                      </div>

                      <div className="d-flex justify-content-end pt-3">
                        <button type="button" className="btn btn-light btn-lg">
                          Reset all
                        </button>
                        <button
                          type="button"
                          className="btn btn-warning btn-lg ms-2"
                          onClick={(e) => handleSave(e)}
                        >
                          Submit form
                        </button>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>
    );
  };
};
export default Registration;
