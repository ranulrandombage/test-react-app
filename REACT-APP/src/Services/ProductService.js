import http from "../http-common";

const getAll = () => {
  return http.get("/product");
};

const get = id => {
  return http.get(`/product/${id}`);
};

const create = data => {
  return http.post("/Product/AddProduct", data);
};

const update = (id, data) => {
  return http.put(`/product/${id}`, data);
};

const remove = id => {
  return http.delete(`/product/${id}`);
};

const removeAll = () => {
  return http.delete(`/product`);
};

const findById = id => {
  return http.get(`/product?id=${id}`);
};

const ProductService = {
  getAll,
  get,
  create,
  update,
  remove,
  removeAll,
  findById
};

export default ProductService;