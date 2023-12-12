import logo from './logo.svg';
import { Routes,Route,Link } from 'react-router-dom';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';

import AddProduct from './Components/AddProduct'
import Product from './Components/Product'
import ProductList from './Components/ProductList'

function App() {
  return (
    <div>
          <nav className='navbar navbar-expand navbar-dark bg-dark'>
      <a href='/products' className='navbar-brand'>
        Test products
      </a>
      <div className='navbar-nav mr-auto'>
        <li>
        <Link to={"Products"} className='nav-link'>
          Products
        </Link>
        </li>
      <li className='nav-item'>
        <Link to={"./add"} className='nav-link'></Link>
        Add
      </li>
      </div>
      </nav>
      <div className='container mt-3'>
      <Routes>
        <Route path="/" element={<ProductList/>}/>
        <Route path="/products" element={<ProductList/>}/>
        <Route path="/add" element={<AddProduct/>}/>
        <Route path="/product/:id" element={<Product/>}/>
      </Routes>
      </div>
      </div>

  );
}

export default App;
