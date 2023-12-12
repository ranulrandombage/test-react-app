import axios from "axios";

export default axios.create({
  baseURL: "https://localhost:7104/api",
  headers: {
    "Access-Control-Allow-Credentials": true,
    "Content-type": "application/json"
  }
});